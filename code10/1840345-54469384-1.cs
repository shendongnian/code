    if (typeof(T).GetInterfaces().Any(
      i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollectionResponse<>)))
    {
      Console.WriteLine($"Do something for {param}");
    }
