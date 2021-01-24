     protected void btnSubmitCompany_Click(object sender, EventArgs e)
        {
    txtCompanyName.BorderColor = System.Drawing.Color.White;
    
    if (txtCompanyName.Text="")
    {
    txtCompanyName.BorderColor = System.Drawing.Color.Red;
    //Add error message if you want
    }
    else
    {
    if (Page.IsValid)
            {
                // Creating a new connection to the database. 
                -- Insert Connection String --
    
                // Creating a new command to insert the input values into the database.
                SqlCommand SubmitCompanyCmd = new SqlCommand("Insert into Employer ([EmployerID], [Name], [Status], [Remarks], [DateLastModified], [LastModifiedBy]) Values(@inputCoID, @inputCoName, @inputCoStatus, @inputCoRemarks, @currentDateTime, 'Admin')", conn);
    
                SubmitCompanyCmd.Parameters.AddWithValue("@inputCoID", txtCompanyID.Text);
                SubmitCompanyCmd.Parameters.AddWithValue("@inputCoName", txtCompanyName.Text);
                SubmitCompanyCmd.Parameters.AddWithValue("@inputCoStatus", ddlCompanyStatus.Text);
                SubmitCompanyCmd.Parameters.AddWithValue("@inputCoRemarks", txtCompanyRemarks.Text);
                SubmitCompanyCmd.Parameters.AddWithValue("@currentDateTime", DateTime.Now);
    
                conn.Open();
                SubmitCompanyCmd.ExecuteNonQuery();
                conn.Close();
                lblSuccessMsg.Text = "Yay. xqc";
    }
    }
