    Type[] types = Assembly.GetExecutingAssembly().GetTypes();
    List<Type> myTypes = new List<Type>();
    foreach (Type t in types)
    {
      if (t.Namespace=="My.Fancy.Namespace")
        myTypes.Add(t);
    }
