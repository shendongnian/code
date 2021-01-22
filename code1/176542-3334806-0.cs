     protected void chkEditable_OnCheckedChanged(object sender, EventArgs e)
            {
                GridViewRow gv = (GridViewRow)(((Control)sender).NamingContainer);
                int pk  = this.GridView1.DataKeys[gv.RowIndex].Value.ToString();
                // Get the reference of this CheckBox
    
                CheckBox chk = gv.FindControl("chkEditable") as CheckBox ;
                //do stuff
              
            }
