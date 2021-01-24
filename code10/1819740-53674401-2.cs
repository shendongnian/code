    //In the .aspx:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    
    //In the .aspx.cs:
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = SomeMethod();
    }
    
    public string SomeMethod()
    {
        return "Foo";
    }
