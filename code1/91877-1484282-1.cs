    private void NavigateFacet(XmlSchemaFacet facet)
    {
        var length = facet as XmlSchemaLengthFacet;
        if (length != null)
        {
            handler.Length(length);
            return;
        }
        var minlength = facet as XmlSchemaMinLengthFacet;
        if (minlength != null)
        {
            handler.MinLength(minlength);
            return;
        }
        var maxlength = facet as XmlSchemaMaxLengthFacet;
        if (maxlength != null)
        {
            handler.MaxLength(maxlength);
            return;
        }
        ...
    }
