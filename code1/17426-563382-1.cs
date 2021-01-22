    //Library
    public class MyComponent
    {
      //Constructor
      public MyComponent(NameValueCollection settings)
      {
         //do something with your settings now, like assign to a local collection
      }
    }
    //Consumer
    class Program
    {
      static void Main(string[] args)
      {
        MyComponent component = new MyComponent(ConfigurationManager.AppSettings);
      }
    }
