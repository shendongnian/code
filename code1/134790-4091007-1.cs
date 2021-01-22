    [return: MyAttribute]   
    public int Method() { ... }
    public int Property {
      get;
      [param: MyAttribute] // applies to the parameter to the setter
      set;
    }
