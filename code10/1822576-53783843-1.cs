    public static List<DataAccess.Reservation> GetListReservation()
    {
        try
        {
            var reservationModels = new List<ReservationModel>();
            
            foreach (var reservation in SelectListReservation())
            {
                reservationModels.Add(new ReservationModel
                {
                    // Again, these are made-up properties for illustration purposes
                    ReservationId = reservation.ReservationId,
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate,
                    CustomerId = reservation.CustomerId
                });
            }
            
            return reservationModels;
        }
        catch (Exception e)
        {
            // You should probably log the exception here or do something with it 
            // besides just re-throwing it
            throw e;
        }
    }
