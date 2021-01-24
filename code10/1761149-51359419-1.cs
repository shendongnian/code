    if (Request.QueryString["Product"] != null)
    {
        string product = Request.QueryString["Product"].ToString();
    
        if (DropDownList1.Items.Cast<ListItem>().Any(x => x.Value == product))
        {
            DropDownList1.SelectedValue = product;
        }
    }
