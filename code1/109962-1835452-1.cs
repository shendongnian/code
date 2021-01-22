    <style type="text/css">
        .pointer
        {
            cursor:default;
        }
    </style>
    <asp:ImageButton ID="ImageButton1" runat="server" 
         ImageUrl="~/Images/image.bmp" Enabled="false" />
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton1.CssClass = !ImageButton1.Enabled ? "pointer" : "";
    }
