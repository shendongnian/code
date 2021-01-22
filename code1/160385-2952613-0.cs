    protected void getEmailGroup()
        {
            Control[] allControls = FlattenHierachy(Page);
            foreach (Control control in allControls)
            {
                if (control.ID != null &&
                    ((control is TextBox && (TextBox)control.Text = "" )
                      || (control is DropDownList && (DropDownList)control.SelectedIndex != -1 ))
                 {
                     if (control.ID.StartsWith("GenInfo_"))
                        GenInfo = true;
                     if (control.ID.StartsWith("EmpInfo_"))
                         EmpInfo = true;
                    
                 }
               }
            }
        }
