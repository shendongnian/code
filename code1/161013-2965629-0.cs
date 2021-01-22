    class Base
    {
      public String Value { get; protected set; }
    }
    
    class SpecialChild : Base
    {
      public void SetValue(String newValue) { this.Value = newValue; }
    }
    // Somewhere else
    SpecialChild special = foo as SpecialChild;
    if (special != null)
    {
      special.SetValue('newFoo');
    }
    else
    {
      foo.DoSomeStuff();
    }
