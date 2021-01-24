    static void Main(string[] args)
    {
       var request = new Content()
       {
          Value = new Request()
          {
             Arguments = new VarArgs[]
             {
                new VarArgs()
                {
                   Title = "Test",
                   Owner = "Skaner",
                }
             }
          }
       };
    
       var text = JsonConvert.SerializeObject(
          request,
          Formatting.None, 
          new PropertyAsObjectConverter(typeof(VarArgs)));
    
       Console.WriteLine(text);
    }
