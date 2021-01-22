    public MyTypeWithNamespaces
    {
        this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
            new XmlQualifiedName(string.Empty, "urn:Abracadabra"), // Default Namespace
            new XmlQualifiedName("w", "urn:Whoohoo")
        });
    }
