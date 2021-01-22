      public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string userName = context.Request["user"];
            int score = int.Parse(context.Request["score"]);
            //And store it in DB
        }
     }
