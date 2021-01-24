    public Foo FooUpdate(Foo item, params Action<Foo>[] propertySetters)
    {
           foreach(var propertySetter in propertySetters)
           {
                propertySetter(item);
           }
           return item;
    }
