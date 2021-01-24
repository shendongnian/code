    protected void someBtn_Click(object o, eventags e)
    {
        if (Request["txtFirstName"].ToString().Trim() == "")
        {
            txtFirstName.BackColor = System.Drawing.Color.Yellow;
            lblError.Text = "ERROR";
            return;
        }
        ....repeat this for all check
        //If everything checks off 
        Session["txtFirstName"] = txtFirstName.Text;
        Session["txtLastName"] = txtLastName.Text;
        Session["txtPayRate"] = txtPayRate.Text;
        Session["txtStartDate"] = txtStartDate.Text;
        Session["txtEndDate"] = txtEndDate.Text;
        
        ....and whatever is left to do
    }
