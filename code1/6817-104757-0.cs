    ClassWithListProperty obj = new ClassWithListProperty();
    obj.List.Add(1);
    obj.List.Add(2);
    obj.List.Add(3);
    
    Type type = obj.GetType();
    PropertyInfo listProperty = type.GetProperty("List", BindingFlags.Public);
    IEnumerable listObject = (IEnumerable) listProperty.GetValue(obj, null);
    
    foreach (int i in listObject)
        Console.Write(i); // should print out 123
