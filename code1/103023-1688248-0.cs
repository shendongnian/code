    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        //your handler will need somehing like http://xxxxx/Image.ashx?file=toto.png
        //(humm I suggest you to put adamantite++ validations here :p)
        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["file"];
            context.Response.WriteFile(fileName);
        }
    }
