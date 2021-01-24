    public class Project
    {
        // Name for your root element.  Replace as desired.
        public const string RootElementName = "Project";
        // Namespace for your project.  Replace as required.
        public const string RootElementNamespaceURI = "https://stackoverflow.com/questions/49977144";
        public string BaseProperty { get; set; }
    }
    public class ProjectCustomerA : Project
    {
        public string CustomerProperty { get; set; }
        public string ProjectCustomerAProperty { get; set; }
    }
    public class ProjectCustomerB : Project
    {
        public string CustomerProperty { get; set; }
        public string ProjectCustomerBProperty { get; set; }
    }
