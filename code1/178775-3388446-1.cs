    var dates = new List<DateTime>
    				{
    					new DateTime( 2010, 01, 01 ), 
    					new DateTime( 2010, 01, 02 ), 
    					new DateTime( 2010, 01, 03 ), 
    					new DateTime( 2010, 01, 05 )
    				};
    
    var targetDate = new DateTime( 2010, 01, 01 );
    
    var missingDates = new List<DateTime>();
    while ( targetDate <= new DateTime( 2010, 01, 06 ) )
    {
    	if ( !dates.Contains( targetDate ) )
    		missingDates.Add( targetDate );
    
    	targetDate = targetDate.AddDays( 1 );
    }
    
    foreach ( var date in missingDates )
    	Debug.WriteLine( date.ToString() );
	
	
