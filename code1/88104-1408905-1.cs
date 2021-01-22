    protected void Button1_Click(object sender, EventArgs e)
    {
        if (LoginCheck()) 
        {
            Session.RemoveAll();
            Button1.PostBackUrl = "~/Default.aspx";
            Response.Redirect("~/Default.aspx");
        }
    }
