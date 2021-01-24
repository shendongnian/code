    public static List<ReservationModel> GetListReservation()
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
