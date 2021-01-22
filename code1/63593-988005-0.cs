    Foo f = new Foo();
    f.Bar = "Jon Skeet is god.";
    foreach(var property in f.GetType().GetProperties())
    {
        if(property.Name != "Bar")
        {
             continue;
        }
        object o = property.GetValue(f,null); //throws exception TargetParameterCountException for String type
    }
