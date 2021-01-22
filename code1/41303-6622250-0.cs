    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
     
    //service.Credentials = new NetworkCredential( "{Active Directory ID}", "{Password}", "{Domain Name}" );
     
    service.AutodiscoverUrl( "First.Last@MyCompany.com" );
    	
    FindItemsResults<Item> findResults = service.FindItems(
       WellKnownFolderName.Inbox,
       new ItemView( 10 ) );
     
    foreach ( Item item in findResults.Items )
    {
       Console.WriteLine( item.Subject );
    }
