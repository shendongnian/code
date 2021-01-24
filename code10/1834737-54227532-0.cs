    public class ISomething
    {
       public Action<string,ISomething> MyCallBack { get; set; }
    }
    
    public class Server
    {
       private List<ISomething> mPlugins = new List<ISomething>();
    
       public Server()
       {
          LoadPlugins();
       }
    
       private void LoadPlugins()
       {
          foreach (var plugin in mPlugins)
             plugin.MyCallBack += MyCallBack;
       }
    
       private void MyCallBack(string message, ISomething plugin)
       {
          Console.WriteLine(message);
       }
    }
