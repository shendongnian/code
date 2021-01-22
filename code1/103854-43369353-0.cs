    <asp:PlaceHolder ID="myPlaceHolder" runat="server">
        <hr id="someElement" runat="server" />
    </asp:PlaceHolder>
    protected void Page_Init(object sender, EventArgs e)
    {
        myPlaceHolder.SetRenderMethodDelegate(ClosingRenderMethod);
    }
    protected void ClosingRenderMethod(HtmlTextWriter output, Control container)
    {
        var voidTags = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "br", "hr", "link", "img" };
        foreach (Control child in container.Controls)
        {
            var generic = child as HtmlGenericControl;
            if (generic != null && voidTags.Contains(generic.TagName))
            {                
                output.WriteBeginTag(generic.TagName);
                output.WriteAttribute("id", generic.ClientID);
                generic.Attributes.Render(output);
                output.Write(HtmlTextWriter.SelfClosingTagEnd);                
            }
            else
            {
                child.RenderControl(output);
            }
        }
    }
