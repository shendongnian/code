    public class HtmlFormAdapter : ControlAdapter
        {
            protected override void Render(HtmlTextWriter writer)
            {
                HtmlForm form = this.Control as HtmlForm;
                if (form == null)
                {
                    throw new InvalidOperationException("Can only use HtmlFormAdapter as an adapter for an HtmlForm control");
                }
    
                base.Render(new CustomActionTextWriter(writer));
            }
    
            public class CustomActionTextWriter : HtmlTextWriter
            {
                public CustomActionTextWriter(HtmlTextWriter writer) : base(writer)
                {
                    this.InnerWriter = writer.InnerWriter;
                }
    
                public override void WriteAttribute(string name, string value, bool fEncode)
                {
            public override void WriteAttribute(string name, string value, bool fEncode)
            {
		if (name == "action")
		{
			value = "";
		}		
                base.WriteAttribute(name, value, fEncode);  //// override action
            }
        }
}
