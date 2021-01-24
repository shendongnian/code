    // If all textboxes are populated, pass the values to the frmPersonnelVerified page
    if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtPayRate.Text) && !string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
        {
          string delim = "\n";
            Session["txtData"] = txtFirstName.Text + delim + 
                                 txtLastName.Text + delim +
                                 txtPayRate.Text + delim + 
                                 txtStartDate.Text + delim + 
                                 txtEndDate.Text; 
            //Need to set session variables for all text boxes
            Response.Redirect("frmPersonnelVerified.aspx");
        }
