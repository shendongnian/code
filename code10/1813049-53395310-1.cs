    //TODO: put the right types for TypeOfProp1, TypeOfProp2, TypeOfProp3
    var prop1Values = new HashSet<TypeOfProp1>(); 
    var prop2Values = new HashSet<TypeOfProp2>();
    var prop3Values = new HashSet<TypeOfProp3>();
    
    foreach (var item in collection) {
      prop1Values.Add(item.Prop1);
      prop2Values.Add(item.Prop2);
      prop3Values.Add(item.Prop3);
    }
