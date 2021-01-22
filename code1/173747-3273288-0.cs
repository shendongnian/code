    using System;
    using System.IO;
    using System.Net;
    using System.Xml.Linq;
    using System.Web;
    
    class Test
    {
        static void Main()
        {
            string url = "http://google.com/xrds/xrds.xml";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            
            XDocument doc;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    doc = XDocument.Load(stream);
                }
            }
            // Now do whatever you want with doc here
            Console.WriteLine(doc);
        }   
    }
