    class Program
    {
      static void Main(string[] args)
      {
        ParseJson pjs = new ParseJson();
        GetJson gjson = pjs.Serializer();
        ConfigModel cf = gjson.RetrieveValues();
        //cf.Username and other members
        
        //OR you can have:  ConfigModel cf = pjs.Serializer().RetrieveValues();
      }
    }
