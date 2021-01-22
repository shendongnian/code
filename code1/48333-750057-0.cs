    static bool Foo<T>()
    {
      return typeof(IEnumerable<int>).IsAssignableFrom(typeof(T));
    }
    
    Foo<List<T>>();  // true
    Foo<int>(); // false
