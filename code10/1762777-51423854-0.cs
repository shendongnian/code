      using System.Reflection;
      ...  
      Type[] generics = typeof(Test1)
        .BaseType               // Test<K, V>
        .GetGenericArguments(); // {K, V}
      Console.Write(string.Join(", ", generics.Select(t => t.Name)));
