    TicketBooker tb = new TicketBooker();
    tb.BookingSuccessfull += this.ShowSuccessMessage;
    // ...
    public void ShowSuccessMessage()
    {
        // simply display success message in interface, eg. by setting label text
    }
