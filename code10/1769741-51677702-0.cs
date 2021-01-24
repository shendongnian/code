    var c = new MyClass();
    var props = c.GetType().GetProperties()
        .Where(prop => Attribute.IsDefined(prop, typeof(MyAttribute)));
    foreach (var prop in props)
    {
        MyAttribute myAttr = (MyAttribute)Attribute.GetCustomAttribute(prop, typeof(MyAttribute));
        if (myAttr.Name == "Something2")
            break; //you got it
    }
