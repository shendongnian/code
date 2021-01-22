    public class Hello {
        public string Name { get; set; }
    }
    
    public class HelloResponse {
        public string Result { get; set; }
    }
    
    public class HelloService : IService<Hello> {
        public object Execute(Hello request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }
