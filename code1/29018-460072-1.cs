    public class FolderFile : IReadableFile
    {
        readonly private string _name;
    
        public FolderFile(string name)
        {
            _name = name;
        }
    
        #region IFile Members
    
        public Stream OpenRead()
        {
            return File.OpenRead(_name);
        }
    
        #endregion
    }
    
    public class FolderRepository : IRepository
    {
        readonly private string _directory;
    
        public FolderRepository(string directory)
        {
            _directory = directory;
        }
    
        #region IRepository Members
    
        public IEnumerable<IReadableFile> Search(string pattern)
        {
            return Array.ConvertAll(Directory.GetFiles(_directory, pattern), name => new FolderFile(name));
        }
    
        #endregion
    }
    
    public class AssemblyFile : IReadableFile
    {
        readonly private Assembly _assembly;
        readonly private string _name;
    
        public AssemblyFile(Assembly assembly, string name)
        {
            _assembly = assembly;
            _name = name;
        }
    
        #region IReadableFile Members
    
        public Stream OpenRead()
        {
            return _assembly.GetManifestResourceStream(_name);
        }
    
        #endregion
    }
    
    public class AssemblyRepository : IRepository
    {
        readonly private Assembly _assembly;
    
        public AssemblyRepository(Assembly assembly)
        {
            _assembly = assembly;
        }
    
        #region IRepository Members
    
        public IEnumerable<IReadableFile> Search(string pattern)
        {
            return _assembly.GetManifestResourceNames().Where(name => name.Contains(pattern)).Select(name => new AssemblyFile(_assembly, name)).ToArray();
        }
    
        #endregion
    }
