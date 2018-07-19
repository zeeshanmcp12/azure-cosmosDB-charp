using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ConsoleApplication1
{
    class JsonData
    {
        public string name { get; set; }
        public int id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string EndpointUrl = @"";
            const string PrimaryKey = @"";
            DocumentClient client;
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
            try
            {
                IOrderedQueryable<JsonData> familyQuery = client.CreateDocumentQuery<JsonData>(
                        UriFactory.CreateDocumentCollectionUri("", ""), queryOptions);
                foreach (var x in familyQuery)
                {
                    Console.WriteLine(" \tRead {0}", x.id + " " + x.name);
                }
                Console.Read();
            }
            catch(Exception ex)
            {

                ex.Message.ToString();
            }
        }
    }
}
