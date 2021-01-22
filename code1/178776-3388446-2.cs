    var dates = new List<DateTime>
    				{
    					new DateTime( 2010, 01, 01 ), 
    					new DateTime( 2010, 01, 02 ), 
    					new DateTime( 2010, 01, 03 ), 
    					new DateTime( 2010, 01, 05 )
    				};
    var calendar = new List<DateTime>();
    var targetDate = new DateTime( 2010, 01, 01 );
    while ( targetDate <= new DateTime( 2010, 01, 06 ) )
    {
    	calendar.Add( targetDate );
    	targetDate = targetDate.AddDays( 1 );
    }
    
    var missingDates = ( from date in calendar
    			  where !dates.Contains( date )
    			  select date ).ToList();
    
    foreach ( var date in missingDates )
    	Debug.WriteLine( date.ToString() );
