    public class Service1 : IService1 {
        public Task<string> GetData() {
            http test = new http(); 
            return test.HttpRequestAsync();
        }
    }
    
