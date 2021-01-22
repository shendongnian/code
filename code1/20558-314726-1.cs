    // Handle the grid's RowDataBound event
    MyGridView.RowDataBound += new GridViewRowEventHandler(MyGridView_RowDataBound);
    
    // Set the value to x / 1000 in the RowDataBound event
    protected void MyGridView_RowDataBound( object sender, GridViewRowEventArgs e )
    {
        if( e.Row.RowType != DataControlRowType.DataRow )
          return;
        // Cast e.Row.DataItem to whatever type you're binding to
        BindingObject bindingObject = (BindingObject)e.Row.DataItem;
        // Set the text of the correct column.  Replace 0 with the position of the correct column
        e.Row.Cells[0].Text = bindingObject.ProcessingTime / 1000M;
    }
