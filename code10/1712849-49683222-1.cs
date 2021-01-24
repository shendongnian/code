    internal sealed class MySerializer : ODataResourceSerializer
    {
      public MySerializer(ODataSerializerProvider sp) : base(sp) { }
      public override ODataResource CreateResource(SelectExpandNode selectExpandNode, ResourceContext resourceContext)
      {
          ODataResource resource = base.CreateResource(selectExpandNode, resourceContext);
          if (resource != null && resourceContext.ResourceInstance is Bar b)
              resource = BarToResource(b);
          return resource;
      }
      private ODataResource BarToResource(Bar b)
      {
          var odr = new ODataResource
          {
              Properties = new List<ODataProperty>
              {
                  new ODataProperty
                  {
                      Name = "Name",
                      Value = b.Name
                  },
                  new ODataProperty
                  {
                      Name = "Value",
                      Value = b.Value is DateTime dt ? new DateTimeOffset(dt) : b.Value
                  },
                  new ODataProperty
                  {
                      Name = "Group",
                      Value = b.Group
                  },
              }
          };
          return odr;
      }
    }
