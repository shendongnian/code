    private string guest {get; set;}
    protected void Page_Load(object sender, EventArgs e)
    {
        guest = Session["consumer"].ToString(); 
    }
    protected void user_SelectedIndexChanged(object sender, EventArgs e)
    {
         user.text = guest;
    }
