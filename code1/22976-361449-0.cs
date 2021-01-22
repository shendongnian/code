    private string InternalSomeFunction(string param1, int param2)
    {
      /* implementation goes here */
    }
    
    public string SomeFunction(string param1, int param2)
    {
      if (string.IsNullOrEmpty(param1)) {
        throw new ArgumentException("bla", "param1");
      }
      if (param2 < 0 || param2 > 100 || param2 == 53) {
        throw new ArgumentOutOfRangeException("eek", "param2");
      }
      return InternalSomeFunction(param1, param2);
    }
