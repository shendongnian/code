    public event Action BookingSuccessfull;
    public void BookTicket()
    {
        // grab ticket info from database
        // validate dates
        // validate user info
        // send data to operator
        // ... here comes lot more stuff you might want to do
        if (booked)
        {
            // now we raise event, notifying all interested observers 
            this.BookingSuccessfull();
        }
    }
