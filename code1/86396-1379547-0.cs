     public bool UpdateReservation(Reservation reservation)
    {
        bool success = false;
        try
        {
            ResDataContext db = new ResDataContext ();
            Reservation res = db.Reservations.Where(r => r.ReservationNumber == reservation.ReservationNumber).Single();
            db.Reservations.InsertOnSubmit(res);
            db.SubmitChanges();
            success = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("");
        }
        return success;
    }
