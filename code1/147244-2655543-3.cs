    enum FooProperties
    {
    	Bar,
    	Baz,
    }
    
    object[] properties = new object[2];
    
    public object this[FooProperties property]
    {
        get
        {
            if (properties[property] == null)
            {
               properties[property] = GetProperty(property);
            }
            return properties[property];           
        }
        set
        {
            properties[property] = value;
        }
    }
    
    private object GetProperty(FooProperties property)
    {
        switch (property)
        {
             case FooProperties.Bar:
                  if (innerFoo != null)
                      return innerFoo.GetBar();
                  else
                      return (int)0;
             case FooProperties.Baz:
                  if (innerFoo != null)
                      return innerFoo.GetBaz();
                  else
                      return (int)0;
             default:
                  throw new ArgumentOutOfRangeException();
        }
    }
