    [XmlRoot("MyTypeWithNamespaces", Namespace="urn:Abracadabra", IsNullable=false)]
    public class MyTypeWithNamespaces
    {
        // As noted below, per Microsoft's documentation, if the class exposes a public
        // member of type XmlSerializerNamespaces decorated with the 
        // XmlNamespacesDeclarationAttribute, then the XmlSerializer will utilize those
        // namespaces during serialization.
        public MyTypeWithNamespaces( )
        {
            this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                // Don't do this!! Microsoft's documentation explicitly says it's not supported.
                // It doesn't throw any exceptions, but in my testing, it didn't always work.
                // new XmlQualifiedName(string.Empty, string.Empty),  // And don't do this:
                // new XmlQualifiedName("", "")
                // DO THIS:
                new XmlQualifiedName(string.Empty, "urn:Abracadabra") // Default Namespace
                // Add any other namespaces, with prefixes, here.
            });
        }
        // If you have other constructors, make sure to call the default constructor.
        public MyTypeWithNamespaces(string label, int epoch) : this( )
        {
            this._label = label;
            this._epoch = epoch;
        }
        // An element with a declared namespace different than the namespace
        // of the enclosing type.
        [XmlElement(Namespace="urn:Whoohoo")]
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        private string _label;
        // An element whose tag will be the same name as the property name.
        // Also, this element will inherit the namespace of the enclosing type.
        public int Epoch
        {
            get { return this._epoch; }
            set { this._epoch = value; }
        }
        private int _epoch;
        // Per Microsoft's documentation, you can add some public member that
        // returns a XmlSerializerNamespaces object. They use a public field,
        // but that's sloppy. So I'll use a private backed-field with a public
        // getter property. Also, per the documentation, for this to work with
        // the XmlSerializer, decorate it with the XmlNamespaceDeclarations
        // attribute.
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces
        {
            get { return this._namespaces; }
        }
        private XmlSerializerNamespaces _namespaces;
    }
