    protected void Page_Load(object sender, EventArgs e)
    {
        Control c = FindControlRecursive("MyLiteral1", GlobalContentPlaceHolderBody);
        if(c != null)
            ((Literal)c).Text = "Test";
    }
