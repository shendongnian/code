      public Directory WithDirectory(IEnumerable<string> directories)
      {
        Directory current = this;
        foreach(string d in directories)
          current = current.WithDirectory(d);
        return current;
      }
      public File WithFile(IEnumerable<string> directories, string name)
      {
        return this.WithDirectory(directories).WithFile(name);
      }
