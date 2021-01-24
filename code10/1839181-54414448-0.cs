    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserType"].ToString() == "Admin")
        {
            btnSave.Visible = true;
        }
        else
        {
            btnSave.Visible = false;
        }
    }
