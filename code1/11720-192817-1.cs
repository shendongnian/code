    return AppendFolders(new Params<string>() { baseFolder, callingModuleName, version, extraFolders });
    class Params<T> : List<T> {
        public void Add(IEnumerable<T> collection) {
           base.AddRange(collection);
        }
        public static implicit operator T[](Params<T> a) {
           return a.ToArray();
        }
    }
    
