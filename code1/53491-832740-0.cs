    public class Unserializable
    {
      public int Age { get; set; }
      public int ID { get; set; }
      public string Name { get; set; }
    }
    
    public class Program
    {
      static void Main()
      {
        var u = new Unserializable
                {
                  Age = 40,
                  ID = 2,
                  Name = "Betty"
                };
        var jser = new JavaScriptSerializer();
        var jsonText = jser.Serialize( u );
        // next line outputs {"Age":40,"ID":2,"Name":"Betty"}
        Console.WriteLine( jsonText );
      }
    }
