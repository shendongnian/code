    public MyController : controller
    {
        public void GetSiteMapUrls()
        {
            XmlSerializer serializer = new XmlSerializer(SitemapItems.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, SitemapItems);
        }
    }
