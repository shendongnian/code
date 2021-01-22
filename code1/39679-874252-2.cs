    // explicitly specify a namespace for this type,
    // to be used during XML serialization.
    [XmlRoot(Namespace="urn:Abracadabra")]
    public class MyTypeWithNamespaces
    {
        // private fields backing the properties
        private int _Epoch;
        private string _Label;
        // explicitly define a distinct namespace for this element
        [XmlElement(Namespace="urn:Whoohoo")]
        public string Label
        {
            set {  _Label= value; } 
            get { return _Label; } 
        }
        // this property will be implicitly serialized to XML using the
        // member name for the element name, and inheriting the namespace from
        // the type.
        public int Epoch
        {
            set {  _Epoch= value; } 
            get { return _Epoch; } 
        }
    }
