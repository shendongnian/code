    public class Response : IResponse
    {
        public object this[object Key]
        {
            get
            {
                return "Hello";
            }
        }
    }
    public interface IResponse
    {
        object this[object Key] { get; }
    }
    public class Program
    {
        static async Task Main(string[] args)
        {
            Response response = new Response();
    
            var test = response["fds"]; //I can do this
            var test2 = (response["fds"] as IResponse)?["dsa"]; //But response["fds"] have to be IResponse if it's not you will get null
        }
    }
