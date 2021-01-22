    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        name = "HELP";  // your code here
        btnSubmit.PostBackUrl = "http://newserver/page.aspx";
        ClientScript.RegisterStartupScript(this.GetType(), "autopostback", ClientScript.GetPostBackEventReference(btnSubmit, ""));
    }
