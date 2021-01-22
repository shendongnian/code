    protected void Button1_Click(object sender, EventArgs e)
    {
        if(dropdownlist1.SelectedValue == "IC No")
        {
            // assuming this is the redirect to your patients details view
            // but you MUST use only forward slashes to make it work (!)
            Response.Redirect("~/searchpage.aspx?PatientNRIC=" + TextBox1.Text);
        }
    }
