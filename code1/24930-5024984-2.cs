    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "AddToCart")
      {
        // Retrieve the row index stored in the 
        // CommandArgument property.
        int index = Convert.ToInt32(e.CommandArgument);
        // Retrieve the row that contains the button 
        // from the Rows collection.
        GridViewRow row = GridView1.Rows[index];
        // Add code here to add the item to the shopping cart.
      }
    }
