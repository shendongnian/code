    protected void DeleteFile(object sender, EventArgs e)
    {
       LinkButton clicked = (LinkButton)sender;
       Control container = clicked.NamingContainer;
       int id = int.Parse(((Hidden)container.FindControl("FileId")).Value);
       //do stuff with the id, etc.
    }
