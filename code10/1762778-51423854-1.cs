      Test1 myTest = ...
      Type[] generics = myTest
        .GetType()              // Test1
        .BaseType               // Test<K, V>
        .GetGenericArguments(); // {K, V}
