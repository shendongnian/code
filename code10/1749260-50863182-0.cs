     foreach (GridViewRow row in GridView1.Rows)
            {
                var chk = (HtmlInputCheckBox)row.FindControl("checkboxID");
                var selectedRoomID = (Label)row.FindControl("Label2");
                if (chk.Checked && chk != null)
                {
                    
                    Label1.Text = selectedRoomID.Text;
                }
                else
                   {
                  Label1.Text = "error";
                    }
