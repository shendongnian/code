    public int doSomeWork(string value)
    {
      return int.Parse(value ?? "0");
    }
    public int doSomeWork(string value)
    {
       if(value == null)
          value = "0";
        int SomeValue = int.Parse(value);
        return SomeValue;
    }
