     protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Image1.ImageUrl = "~/images/" + DropDownList1.SelectedItem.Value;
        }
    
