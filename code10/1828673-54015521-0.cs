    public static void Main()
    {
        //Make a request and show 'hello world' when the response was received
        Connection<MyResponse>.Request("key", (MyResponse) => {
            Console.WriteLine(MyResponse.Value);
        });
        //set the response making the action write "hello world"
        Connection<MyResponse>.SetResponse("key", new MyResponse("hello world"));
    }
    public class Connection<T> where T: BaseResponse
    {
        static Dictionary<string, Action<T>> _dicActions = new Dictionary<string, Action<T>>();
        public static void Request(string key, Action<T> action)
        {
            _dicActions.Add(key, action);
        }
        public static void SetResponse(string key, T pResponse)
        {
            _dicActions[key](pResponse);
        }
    }
