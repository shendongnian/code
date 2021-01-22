        [WebService(Namespace = "http://localhost/MyWebService/")]
        public class MyWebService : WebService
        {
            [WebMethod]
            public int Add(int a, int b)
            {
                return a + b;
            }
    
            [WebMethod]
            public String SayHello()
            {
                return "Hello World";
            }
        }
