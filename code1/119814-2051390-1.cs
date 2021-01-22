    private static Attribute[] BrowsableAttributeList
    {
        get
        {
            if (browsableAttribute == null)
            {
                browsableAttribute = new Attribute[] { new BrowsableAttribute(true) };
            }
            return browsableAttribute;
        }
    }
