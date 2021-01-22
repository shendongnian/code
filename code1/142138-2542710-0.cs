Use the is operator:
    public bool Equals(object obj)
    {
      if (obj is MyStruct)
      {
        var o = (MyStruct)obj;
        ...
      }
    }
