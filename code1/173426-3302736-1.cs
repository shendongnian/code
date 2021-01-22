    protected void rptFolders_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Book book = (Book)e.Item.DataItem; //Or whatever your passing
    
            ImageButton btnImage = e.Item.FindControl("btnImage");
            LinkButton btnLink = e.Item.FindControl("btnLink");
    
            btnLink.Text = book.Name;
    
            btnLink.Click += new EventHandler(FolderClicked);
            btnImage.Click += new ImageClickEventHandler(FolderClicked);
        }
    }
