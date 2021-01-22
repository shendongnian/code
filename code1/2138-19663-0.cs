    foreach (Type t in Assembly.GetCallingAssembly().GetTypes())
    {
      if (!t.IsAssignableFrom(typeof(IStep))) continue;
      Console.WriteLine(t.FullName + " implements " + typeof(IStep).FullName);
    }
