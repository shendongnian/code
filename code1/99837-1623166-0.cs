    //  Read the selected seats and store them
    OnCheckChanged( ... )
    {
       Dictionary<Route,Seat> reservedSeats = Session["reservedSeats"] as Dictionary<Route,Seat>;
       reservedSeats[Current Route] = Selected Seat;
       Session["reservedSeats"] = reservedSeats;
    }
    
    //  Show the selected seats when they come to a specific route
    OnLoad(...)
    {
       Dictionary<Route,Seat> reservedSeats = Session["reservedSeats"] as Dictionary<Route,Seat>;
       SetSeatSelection( reservedSeats[Current Route] );
    }
