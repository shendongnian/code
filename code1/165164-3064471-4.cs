    class DirectorySource<T>: IDirectorySource<T> {
      // Or you could put the parameter in constructor if this is not the only place
      // where you create new instances of T
      public IList<T> ToList(Func<DirectoryEntry, T> create) {
        ...
        foreach (var entry in entries)
          entities.Add(create(entry.GetDirectoryEntry()));
        return entities;
      }
    }
    
    IList<Group> groups = new DirectorySource<Group>().ToList(entry => new Group(entry));
