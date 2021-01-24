    public bool InsertRegistration()
    {
        // ...
        using (var conn = new SqlConnection(...))
        {
            using (var com = new SqlCommand("INSERT INTO Candidates..."))
            {
                com.Parameters.AddWithValue("@FirstName", txtFN.Text);
                // ... etc
                con.Open(); // open connection here, just before executing
                // return the true/false for whether a row was inserted
                return com.ExecuteNonQuery() >= 1;
            }
        }
    }
    
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Account/RegMessage.html")))
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
