    string typeName = typeof(Counter<>).AssemblyQualifiedName;
    Type t = Type.GetType(typeName);
    
    Counter<int> counter = 
      (Counter<int>)Activator.CreateInstance(
        t.MakeGenericType(typeof(int)));
    counter.Value++;
    Console.WriteLine(counter.Value);
