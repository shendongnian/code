    int itemId = getItemId();
    SPWeb currentWeb = SPContext.Current.Web;
    SPList list =  currentWeb.Lists["MyList"];
    if ( list != null )
    {
         SPListItem theItem = list.Items.GetItemById(itemId);
         doWork(theItem);
    }
