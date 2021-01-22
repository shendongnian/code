    string[] localizedMonths = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames;
    string[] invariantMonths = DateTimeFormatInfo.InvariantInfo.MonthNames;
    
    for( int month = 0; month < 12; month++ )
    {
    	ListItem monthListItem = new ListItem( localizedMonths[month], invariantMonths[month] );
    	monthsDropDown.Items.Add( monthListItem );
    }
