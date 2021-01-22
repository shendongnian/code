    int interator = 0;
    
    List<Cart> objNewCartItems = (List<Cart>)Session["CartItems"];
    
    objNewCartItems.ForEach( i => i.Quantity = GetCartQuantity(interator++));
    
    Session["CartItems"] = objNewCartItems;            
    Response.Redirect("ItemListing.aspx", false);
    
    private int GetCartQuantity(int interator)
    {
      if ((objNewCartItems != null) && (objNewCartItems.Count > 0))
      {
        Cart c = new Cart();
        TextBox t = (TextBox)dgShoppingCart.Rows[interator].FindControl("txtQuantity");
        c.Quantity = (t.Text == string.Empty? (int?)null: Convert.ToInt32(t.Text));
        return c.Quantity;                
      }
    }
