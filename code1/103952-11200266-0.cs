    [XmlRoot("MyClassWithNullableProp", Namespace="urn:myNamespace", IsNullable = false)]
    public class MyClassWithNullableProp
    {
        public MyClassWithNullableProp( )
        {
            this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                new XmlQualifiedName(string.Empty, "urn:myNamespace") // Default Namespace
            });
        }
        
        [XmlElement("Property1", Namespace="urn:myNamespace", IsNullable = false)]
        public string Property1
        {
            get
            {
                // To make sure that no element is generated, even when the value of the
                // property is an empty string, return null.
                return string.IsNullOrEmpty(this._property1) ? null : this._property1;
            }
            set { this._property1 = value; }
        }
        private string _property1;
        
        // To do the same for value types, you need a "helper property, as demonstrated below.
        // First, the regular property.
        [XmlIgnore] // The serializer won't serialize this property properly.
        public int? MyNullableInt
        {
            get { return this._myNullableInt; }
            set { this._myNullableInt = value; }
        }
        private int? _myNullableInt;
        
        // And now the helper property that the serializer will use to serialize it.
        [XmlElement("MyNullableInt", Namespace="urn:myNamespace", IsNullable = false)]
        public string XmlMyNullableInt
        {
           get 
           {
                return this._myNullableInt.HasValue?
                    this._myNullableInt.Value.ToString() : null;
           }
           set { this._myNullableInt = int.Parse(value); } // You should do more error checking...
        }
        
        // Now, a string property where you want an empty element to be displayed, but no
        // xsi:nil.
        [XmlElement("MyEmptyString", Namespace="urn:myNamespace", IsNullable = false)]
        public string MyEmptyString
        {
            get
            {
                return string.IsNullOrEmpty(this._myEmptyString)?
                    string.Empty : this._myEmptyString;
            }
            set { this._myEmptyString = value; }
        }
        private string _myEmptyString;
        
        // Now, a value type property for which you want an empty tag, and not, say, 0, or
        // whatever default value the framework gives the type.
        [XmlIgnore]
        public float? MyEmptyNullableFloat
        {
            get { return this._myEmptyNullableFloat; }
            set { this._myEmptyNullableFloat = value; }
        }
        private float? _myEmptyNullableFloat;
        
        // The helper property for serialization.
        public string XmlMyEmptyNullableFloat
        {
            get
            {
                return this._myEmptyNullableFloat.HasValue ?
                    this._myEmptyNullableFloat.Value.ToString() : string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this._myEmptyNullableFloat = float.Parse(value);
            }
        }
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces
        {
            get { return this._namespaces; }
        }
        private XmlSerializerNamespaces _namespaces;
    }
