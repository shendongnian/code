    public void Move(string sourceLocationId, destinationLocationId, itemId)
    {
        if( sourceLocationId == destinationLocationId )
            return;
        using( DataContext ctx = new DataContext() )
        {
           Item item = ctx.Items.First( o => o.ItemID == itemId );
           Location destination = 
              ctx.Locations.First( o => o.LocationID == destinationLocationID );
           item.Location = destination;
           
           ctx.SubmitChanges();
        }
    }
