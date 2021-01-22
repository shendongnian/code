    Foo foo = new Foo();
    string aString = 
       foo.GetType().GetMethod("Factory").MakeGenericMethod(string)
           .Invoke(foo, new object[] { "name 1" });
    int anInt = 
       foo.GetType().GetMethod("Factory").MakeGenericMethod(int)
           .Invoke(foo, new object[] { "name 2" });
