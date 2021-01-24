    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                Response response = new Response();
                response.kind = (string)root.Element("kind");
                response.etag = (string)root.Element("etag");
                response.totalResults  = (int)root.Descendants("totalResults").FirstOrDefault();
                response.resultsPerPage = (int)root.Descendants("resultsPerPage").FirstOrDefault();
                XElement items = root.Element("items");
                response.itemKind = (string)items.Element("kind");
                response.itemEtag = (string)items.Element("etag");
                response.id = (string)items.Element("id");
                XElement statistics = items.Element("statistics");
                response.viewCount = (int)statistics.Element("viewCount");
                response.commentCount = (int)statistics.Element("commentCount");
                response.subscriberCount = (int)statistics.Element("subscriberCount");
                response.hiddenSubscriberCount = (Boolean)statistics.Element("hiddenSubscriberCount");
                response.videoCount = (int)statistics.Element("videoCount");
            }
        }
        public class Response
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public int totalResults { get; set; }
            public int resultsPerPage { get; set; }
            public string itemKind { get; set; }
            public string itemEtag { get; set; }
            public string id { get; set; }
            public int viewCount { get; set; }
            public int commentCount { get; set; }
            public int subscriberCount { get; set; }
            public Boolean hiddenSubscriberCount { get; set; }
            public int videoCount { get; set; }
        }
    }
