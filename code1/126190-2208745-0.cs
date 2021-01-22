    public class PortalLinkBuilder : ControlBuilder {
      public override Type GetChildControlType(string tagName, IDictionary attribs) {
        // you need the full name of the types, suppose they're on namespace Portal
        return Type.GetType("Portal." + tagName, true);
      }
      public override void AppendLiteralString(string s) {
        // ignores literals between rows
      }
    }
    [ControlBuilder(typeof(PortalLinkBuilder))]
    public class PortalLink : Control {
      protected override void AddParsedSubObject(object obj) {
        if (Request != null) throw new InvalidOperationException("Too many requests!");
        Request = (Request)obj; // will fail for non-Request objects
      }
      [Browsable(false)] 
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Request Request { get; private set; }
      ...
    }
