       try
            {
                cust_id = txtID.Text;
                submit changes();
                lblmessage.Text = "Data Save";
            }
            catch (Exception ex)
            {
                  lblmessage.Text = "Saving error";
                  cust_id = txtID.Text;
                  submit changes();
    
            }
