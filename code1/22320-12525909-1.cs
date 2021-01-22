       protected void OnCheckedChanged(object sender, EventArgs e)
            {
                bool flag = false;
               
                foreach (GridViewRow row in Grid_InvoiceGarden.Rows)
                {
                    CheckBox chkItem = (CheckBox)row.FindControl("chkSelect");
                    if (chkItem.Checked)
                        flag = true;
                }
                if (flag == true)
                {
                    btnUpdate.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                }      
            }
