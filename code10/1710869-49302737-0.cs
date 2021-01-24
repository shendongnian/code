    public class Foo
    {
        public void FooFunc()
        {
            ...
        }
    }
    public class Bar
    {
        public Foo Foo { get; set; }
    }
    ...
    public void Whatever()
    {
        Bar bar = new Bar();
        bar.Foo = new Foo();
        foreach (PropertyInfo propertyInfo in typeof(Bar).GetProperties())
        {
            // the compiler will not know what the property is!
            // it would only be known at runtime so you will not be 
            // able to access foo
            propertyInfo.PropertyType p = propertyInfo.GetValue(bar) as propertyInfo.PropertyType; // compiler error
            p.FooFunc(); // compiler error
            // you can do this:
            Foo p = propertyInfo.GetValue(bar) as Foo;
            if (p != null) // cast was successful
                p.FooFunc();
            // but you would need such a check for each type you want
            // to include
            // alternatively use conditions based on the type
            object p = propertyInfo.GetValue(bar);
            if (p.GetType() == typeof(Foo))
                ((Foo)p).FooFunc();
        }
    }
