    protected void Page_Load(object sender, EventArgs e)
    {
    //EDIT: if GlobalContentPlaceHolderBody isn't visible here, use this instead:
    //Control c = FindControlRecursive("MyLiteral1", Page.FindControl("GlobalContentPlaceHolderBody"));
        Control c = FindControlRecursive("MyLiteral1", GlobalContentPlaceHolderBody);
        if(c != null)
            ((Literal)c).Text = "Test";
    }
