    Dictionary<Type, Action<XmlSchemaFacet>> HandlerMap = 
       new Dictionary<Type, Action<XmlSchemaFacet>>
    {
       {typeof(XmlSchemaLengthFacet), handler.Length},
       {typeof(XmlSchemaMinLengthFacet), handler.MinLength},
       {typeof(XmlSchemaMaxLengthFacet), handler.MaxLength}
    };
    HandlerMap[facet.GetType()](facet);
