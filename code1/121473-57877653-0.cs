    class PersonDB
    {
      string[] list = { "John", "Sam", "Dave" };
      public void Process(ProcessPersonDelegate f)
      {
        foreach(string s in list) f(s);
      }
    }
