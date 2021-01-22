    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList control = (DropDownList)sender;
    
            RepeaterItem rpItem = control.Parent as RepeaterItem;
            if (rpItem != null)
            {
                Button btn = ((Button)rpItem.FindControl("Button1"));
                btn.Enabled = true;
    
            }
    
        }
