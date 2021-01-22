    var data = new ListReportViewModel();
    data.Title = "Closed Calls";
    data.Headings = new Dictionary<string, string>();
    data.Headings.Add( "TicketID", "ID" );
    data.Headings.Add( "Company.Name", "Company" );
    data.Headings.Add( "Caller.FirstName", "Caller" );
    data.Headings.Add( "Subject", "Reason for Call" );
    data.Headings.Add( "ClosedTime", "Closed" );
    data.Headings.Add( "ClosedBy.LoginName", "Closed By" );
    data.Data = ( from t in _db.Ticket.Include( "Company" ).Include( "Caller" ).Include( "ClosedBy" )
                  where !t.Open
                  orderby t.ClosedTime ascending
                  select t );
    
    return View( "list", data );
