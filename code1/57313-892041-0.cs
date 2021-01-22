    foreach (string name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
    {
      if (name.EndsWith("<name>", StringComparison.InvariantCultureIgnoreCase))
      {
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
        {
          // ...
        }
        break;
      }
    }
