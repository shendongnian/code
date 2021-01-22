    public class HandlerDemo 
    {
        public void Handle(XmlSchemaLengthFacet facet) { ... }
        public void Handle(XmlSchemaMinLengthFacet facet) { ... }
        public void Handle(XmlSchemaMaxLengthFacet facet) { ... }
        ...
    }
    private void NavigateFacet(XmlSchemaFacet facet)
    {
        dynamic handler = new HandlerDemo();
        handler.Handle(facet);
    }
