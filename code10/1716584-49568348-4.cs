    public class http {
        public async Task<string> HttpRequestAsync() {
            var request = GetHttpRequestMessage();
            string str1 = await ExecuteRequest(request);
            Console.WriteLine(str1);
            return str1;
        }
        
        //...code removed for brevity as they are already Task-based
    }
    
