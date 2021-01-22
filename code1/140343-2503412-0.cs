    <cc1:ServerControl1 ID="ServerControl11" runat="server" Text="Text Set"
         ProtectedText="foo" />
    
    protected string ProtectedText { get; set; }
    
    protected override void RenderContents(HtmlTextWriter output)
    {
        output.Write(Text);
        output.Write(ProtectedText);
    }
