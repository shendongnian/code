    using System;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    public class RSSHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            XDocument xdoc = XDocument.Load("Xml file name");
            SyndicationFeed feed = new SyndicationFeed(from e in xdoc.Root.Elements("Element name")
                                                       select new SyndicationItem(
                                                           (string)e.Attribute("title"),
                                                           (string)e.Attribute("content"),
                                                           new Uri((string)e.Attribute("url"))));
            context.Response.ContentType = "application/rss+xml";
            using (XmlWriter writer = XmlWriter.Create(context.Response.Output))
            {
                feed.SaveAsRss20(writer);
                writer.Flush();
            }
        }
    }
