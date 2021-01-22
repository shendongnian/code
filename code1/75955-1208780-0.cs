    // note this "XmlIncludeAttribute" references the derived type.
    // note that in .NET they are in the same namespace, but in XML they are in different namespaces.
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DerivedType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://BaseNameSpace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://BaseNameSpace", IsNullable=true)]
    public partial class MyBaseType : object
    {
    ...
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://DerivedNameSpace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://DerivedNameSpace", IsNullable=true)]
    public partial class DerivedType: MyBaseType 
    {
    ...
    }
