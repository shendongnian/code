    static Attribute[] AddCategory(Attribute[] attributes, string category) {
        Array.Resize(ref attributes, attributes.Length + 1);
        attributes[attributes.Length - 1] = new CategoryAttribute(category);
        return attributes;
    }
    public IntrinsicPropertyDescriptor(IntrinsicPropertyDef propDef)
         : base(propDef.Key, AddCategory(propDef.Attributes, "Foo"))
    {...}
