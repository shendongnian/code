    foreach (Type t in Assembly.GetCallingAssembly().GetTypes())
    {
      if (!typeof(IStep).IsAssignableFrom(t)) continue;
      Console.WriteLine(t.FullName + " implements " + typeof(IStep).FullName);
    }
