    private Dictionary<string, bool> _directories = new Dictionary<string, bool>();
    
    private void CheckDirectory(string directory, bool create)
    {
      if (_directories.ContainsKey(_directories))
      {
        bool exists = Directory.Exists(directory);
        if (create && !exists)
        {
          Directory.CreateDirectory(directory);
        }
        // Add the directory to the dictionary. The value depends on
        // whether the directory previously existed or the method has been told
        // to create it.
        _directories.Add(directory, create || exists);
      }
    }
