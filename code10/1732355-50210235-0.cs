    public void SampleMethod(FooBarObject fooBarObject) {
        if (fooBarObject == null) {
            throw new ArgumentNullException(nameof(fooBarObject));
        }
    
        fooBarObject.Name = "Never forget a towel";
        fooBarObject.Number = 42;
    }
