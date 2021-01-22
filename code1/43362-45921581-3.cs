    public IEnumerable<Foo> GetNonNullFoosWithSomeDoubleValues(IEnumerable<Foo> foos)
    {
         return foos.Where(foo => foo?.SomeDouble != null);
         return foos.Where(foo=>foo?.SomeDouble.HasValue); // compile time error
         return foos.Where(foo=>foo?.SomeDouble.HasValue == true); 
         return foos.Where(foo=>foo != null && foo.SomeDouble.HasValue); //if we don't use C#6
    }
