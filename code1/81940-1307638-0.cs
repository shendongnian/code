    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox c = (CheckBox)sender as CheckBox;
    
        Button btnDel = (Button)ViewsStudGV.FooterRow.FindControl("btnDel");
        CheckBox allchk = (CheckBox)ViewsStudGV.HeaderRow.FindControl("chkSelectAll");
        
        if(c.Checked == false)
        {
        	btnDel.Visible = true;                
        	allchk.Text = "Select None";
        }
        else
        {
        	CheckBox chk;
    
    		foreach (GridViewRow rowItem in ViewsStudGV.Rows)
        	{
            		chk = (CheckBox)(rowItem.Cells[0].FindControl("chkSelect"));
		            chk.Checked = ((CheckBox)sender).Checked;
			if (chk.Checked == true)
			{
				btnDel.Visible = true;                
				allchk.Text = "Select None";
				break;
			}
			else
			{
				btnDel.Visible = false;
				allchk.Text = "Select All";
			}
		}
	    }
    }
