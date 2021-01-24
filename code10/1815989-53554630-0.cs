    protected void GetNameAndPreName()
        {
            int reservationID = Convert.ToInt32(Request.QueryString["reservationID"].ToString());
            ReservationContext _db = new ReservationContext();
            Reservation r = _db.Reservations.SingleOrDefault(reservation => reservation.ReservationID == reservationID);
            (reservationDetail.FindControl("EditName") as TextBox).Text = r.Name;
            (reservationDetail.FindControl("EditPreName") as TextBox).Text = r.PreName;
        }
