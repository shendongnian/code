    public class DocumentFileTypeRegistry 
    {
        IDictionary<int, IFileType> _registeredFileTypes = new Dictionary<int, IFileType>();
        public void RegisterType(IFileType type)
        {
            _registeredFileTypes[type.Id] = type;
        }
        public IFileType GetTypeById(int id)
        {
            return _registeredFileTypes[id];
        }
    }
    public class DocumentFileType : IFileType
    {
        public int Id => 1;
        public string Subfolder => "documents";
    }
    public class PhotoFileType : IFileType
    {
        public int Id => 2;
        public string Subfolder => "photos";
    }
