    public class Foo : IFoo
    {
        private readonly HttpClient httpClient;
    
        public Consumer(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
 
