    gvOrder.Columns[0].FooterText = "Totals:"; 
    gvOrder.Columns[2].FooterText = Convert.ToString(quantity); 
    gvOrder.Columns[4].FooterText = Convert.ToString(priceTotal);
    
    gvOrder.DataSource = orderItemList; 
    gvOrder.DataBind();
    gvOrder.ShowFooter = true; 
