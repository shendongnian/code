    protected void Page_Init(object sender, EventArgs e)
    {
      // first you have to hook up the event
      datagrid.ItemDataBound += datagrid_ItemDataBound;
    }
    // once the grid is being bound, you have to set the status image you want to use
    private void datagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item) {
        Image img = (Image)e.Item.FindControl("ImageControlName");
        if( ValidationFunction() ) {
          img.ImageUrl = "first_status_image.jpg";
        } 
        else 
        {
          img.ImageUrl = "second_status_image.jpg";
        }
      }
    }
