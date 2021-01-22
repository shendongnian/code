    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e) 
    {    
     if(e.Row.RowType == RowType.DataRow)  
     {  
        YourObject _item = (YourObject)e.Row.DataItem; // use quickwatch to figure out how to cast into your desired type
        Literal _litTotal = (Literal)e.Row.FindControl("litTotal");
      _litTotal.Text = _item.Quantity * _item.Price;
     }
    }
