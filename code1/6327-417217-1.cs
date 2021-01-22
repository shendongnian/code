    SomeType value = SomeType.Grapes;
    bool isGrapes = value.Is(SomeType.Grapes); //true
    bool hasGrapes = value.Has(SomeType.Grapes); //true
    
    value = value.Add(SomeType.Oranges);
    value = value.Add(SomeType.Apples);
    value = value.Remove(SomeType.Grapes);
    bool hasOranges = value.Has(SomeType.Oranges); //true
    bool isApples = value.Is(SomeType.Apples); //false
    bool hasGrapes = value.Has(SomeType.Grapes); //false
    
