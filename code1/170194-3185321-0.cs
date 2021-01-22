    //eg in registration page
    protected void CardInfoLink_Click(object sender, EventArgs e)
    {
        //store details entered
        Session["Registered"] = true;
        Session["Username"] = txtUserName.Text; 
        //etc for any other fields
        Response.Redirect("~/CardDetailsPage.aspx");
    }
