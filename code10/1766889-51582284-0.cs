    public async Task<bool> InsertRegistration() 
    {
        // all code
        int rows = await com.ExecuteNonQueryAsync();
        if(rows>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
         protected void btnsendmail_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new 
         StreamReader(Server.MapPath("~/Account/RegMessage.html")))
         {
            // ...
            if (InsertRegistration())
            {
                // Only run if inserted correclty
                smtpClient.Send(msg);
                lblMessage.Text = "Application submitted successfully! ...";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Error submitting application";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            lblMessage.Visible = true;
        }
        }
