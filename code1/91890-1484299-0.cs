    private void NavigateFacet(XmlSchemaFacet facet)
    {
      if (facet is XmlSchemaLengthFacet)
      {
            handler.Length(facet as XmlSchemaLengthFacet);
      }
      else if (facet is XmlSchemaMinLengthFacet)
      {
            handler.MinLength(facet as XmlSchemaMinLengthFacet);
      }
      else if (facet is XmlSchemaMaxLengthFacet)
      {
           handler.MaxLength(facet as XmlSchemaMaxLengthFacet);
      }
    }
