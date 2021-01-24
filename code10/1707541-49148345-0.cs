               if (Session["employeeNo"].ToString() == "12345")
                {                  
                    CheckBox1.Checked = true; // for Check
                    CheckBox1.Enabled = true; // for Enable
                }
                else
                {
                    CheckBox1.Checked = false; // for UnCheck
                    CheckBox1.Enabled = false;  // for Disable
                } 
