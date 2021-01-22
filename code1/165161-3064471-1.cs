          class DirectorySource<T>: IDirectorySource<T> {      
          public DirectorySource(ISearcher<T> searcher) {
            Searcher = searcher;
          }
          public IList<T> ToList() {
            string filter = "...";
            retunr Searcher.FindAll(filter);
          }
        }
        class GroupSearcher: ISearcher<Group> {
          public IList<Group> FindAll(string filter) {
            entries = ...
            var entities = new List<Group>();
            foreach (var entry in entries) 
              entities.Add(new Group(entry.GetDirectoryEntry());
            return entities;
          }
        }
 
    You would then instantiate you DirectorySource like this:
        IDirectorySource<Group> groups = new DirectorySource<Group>(new GroupSearcher());
