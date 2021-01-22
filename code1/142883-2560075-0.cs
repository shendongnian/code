    class Foo 
    {
      static Dictionary<string, string> makeDictionary() 
      {
        return new Dictionary<string, string>
          {
            {"hello", "mum"},
          };
      }
      static Dictionary<string, string> theDictionary = makeDictionary();
    }
