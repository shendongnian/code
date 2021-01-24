    // Given
    public static IEnumerable<T> Factory<T>(int count) where T : Parent, new() 
         => Enumerable.Range(0, count).Select(x => new T());
    ...
    // Usage
    var array = Factory<Parent>(3)
                  .Union(Factory<Child1>(3))
                  .Union(Factory<Child2>(3))
                  .ToArray();
