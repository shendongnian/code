    protected void Page_Load(object sender, EventArgs e)
    {
        // Fetch your XML here and transform it.  This string represents
        // the transformed output
        string content = @"
            <asp:Button runat=""server"" Text=""Hello"" />
            <asp:Button runat=""server"" Text=""World"" />";
        var controls = ParseControl(content);
        foreach (var control in controls)
        {
            // Wire up events, change settings etc here
        }
        // placeHolder is simply an ASP.Net PlaceHolder control on the page
        // where I would like the controls to end up
        placeHolder.Controls.Add(controls);
    }
