    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList control = (DropDownList)sender;
    
            RepeaterItem rpItem = control.NamingContainer as RepeaterItem;
            if (rpItem != null)
            {
                ImageButton btn = ((ImageButton)rpItem.FindControl("Button1"));
                btn.Enabled = true;
    
            }
    
        }
