    public bool AddReservation(Reservation reservation)
    {
        bool success = false;
        try
        {
            MiningDataContext db = new MiningDataContext();
            db.Reservations.InsertOnSubmit(reservation);
            db.SubmitChanges();
   
            ...
        }
        catch { }
        return success;
    }
