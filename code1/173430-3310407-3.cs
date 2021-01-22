    protected void rptFolders_ItemDataBound(object sender, RepeaterItemEventArgs e)        
    {        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)        
        {        
            Book book = (Book)e.Item.DataItem; //Or whatever your passing        
            
            FolderButton btnFolder = e.Item.FindControls("FolderButton1");
            
            btnFolder.Name=book.Name;
            btnFolder.DatabaseId=book.Id;
    
            btnFolder.Click += new EventHandler(FolderClicked);        
        }        
    }     
