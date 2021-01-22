    public class Person
    {
      Dictionary<string, string> attributes = new Dictionary<string, string();
      public string City
      {
        get { return attributes["city"]; }
        set { attributes["city"] = value; }
      }
      public Person()
      {
        City = "New York";
      }
    }
