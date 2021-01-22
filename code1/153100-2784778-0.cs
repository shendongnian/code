        Assembly assembly = Assembly.GetExecutingAssembly();
        Type animal = typeof(Animal);
        foreach (Type t in assembly.GetTypes())
        {
            if (animal.IsAssignableFrom(t))
            {
                //dog or cat hit.
            }
        }
