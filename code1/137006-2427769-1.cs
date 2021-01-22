    [WebMethod]
    public static bool IsTicketAvailable(int NoOfTickets)
    {
        int AvailableTickets = 5;
        return (NoOfTickets > AvailableTickets);
    }
