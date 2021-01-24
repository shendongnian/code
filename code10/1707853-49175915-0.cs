    [Export(typeof(INamespaceHandler))]
    [HandlesNamespace("System", "Data")]
    [HandlesNamespace("System", "Core")]    
    public class NamespaceHandler : INamespaceHandler { }
    
    [MetadataViewImplementation(typeof(NamespaceHandlerMetadata))]
    public interface INamespaceHandlerMetadata
    {
        string[] HandledNamespaces { get; set; }
    }
    
    public class NamespaceHandlerMetadata : INamespaceHandlerMetadata 
    {
        string[] HandledNamespaces { get; set; }
    
        public NamespaceHandlerMetadata(IDictionary<string, object> exportedMetadata)
        {
            HandledNamespaces = exportedMetadata[nameof(HandledNamespaces)];
        }
    }
    
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HandlesNamespaceAttribute : Attribute
    {
        private string _namespaceDelimiter = ".";
    
        // Because the attribute is marked AllowMultiple = true, this will get exported 
        // as a string[], despite it appearing to only be set once in the constructor below
        public string HandledNamespaces { get; }
    
        public ExportHandledNamespaceAttribute(params string[] namespaceIdentifiers) 
               : base(typeof(INamespaceHandler))
        {
            string namespace = String.Join(_namespaceDelimiter, namespaceIdentifiers);
            HandledNamespaces = namespace;
        }
    }
