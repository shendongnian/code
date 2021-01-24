    public class DocumentInfo
    {
        public HashSet<string> SheetNames { get; set; }
        // potentially RowColInfo if it's part of your configuration
    }
    public interface IReader
    {
        HashSet<DataSheet> Read(DocumentInfo docuInfo, ref string errors);
    }
    public class ConcreteReader: IReader
    {
        public ConcreteReader(string filePath) {...};
        public HashSet<DataSheet> Read(DocumentInfo docuInfo, ref string errors) {...};
    }
