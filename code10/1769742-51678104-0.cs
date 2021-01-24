    var c = new MyClass();
    var props = c.GetType()
                 .GetProperties()
                 .Where(prop => prop.GetCustomAttributes(false)
                                    .OfType<MyAttribute>()
                                    .Any(att => att.Name == "Something1"));
