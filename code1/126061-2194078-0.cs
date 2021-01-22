    IEnumerable<MyClass> SetB(IEnumerable<MyClass> allItems, MyType type)
    {
      var result = from item in allItems
                   where item.Type == type && item.Source == "sourceA"
                   select item;
      return result;
    }
    IEnumerable<MyClass> SetC(IEnumerable<MyClass> allItems)
    {
      var result = from item in allItems
                   where item.Source == "sourceB"
                   select item;
      return result;
    }
    IEnumerable<MyClass> SetD(IEnumerable<MyClass> allItems, MyType type)
    {
      var setB = SetB(allItems, type);
      var setC = SetC(allItems);
      return setB.Union(setC);
    }
