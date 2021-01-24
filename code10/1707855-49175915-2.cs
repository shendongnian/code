    public class NamespaceHandlerManager, IPartImportsSatisfiedNotification
    {
        [ImportMany]
        public IEnumerable<Lazy<INamespaceHandler, INamespaceHandlerMetadata>> NamespaceHandlers { get; set; }
    
        public NamespaceHandlerManager() { }
    
        public void OnImportsSatisfied()
        {
            // NamespaceHandlers will be populated with the exports from any 
            // loaded assemblies by this point, do what you want with it
        }
    }
