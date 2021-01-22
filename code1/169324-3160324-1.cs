    class Enums
    {
      public Enum1 Enum1 { get; set; }
      public Enum2 Enum2 { get; set; }
    }
    
    Enums enums = new Enums();
    enums.Enum1 = Enum1.Value1;
    enums.Enum2 = Enum2.AnotherValue;
    
    if (enums.Enum1 == Enum1.Value1)
    ...
