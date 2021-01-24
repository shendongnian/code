    public class SitemapResult : ActionResult
    {
        private object _data;
        public SitemapResult(object data)
        {
           _data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // you can use reflection to determine object type
            XmlSerializer serializer = new XmlSerializer(_data.GetType());
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            serializer.Serialize(response.Output, _data);
        }
    }
