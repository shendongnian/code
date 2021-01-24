    if (ModelState.IsValid)
            {
               if(db.Reservation.where(a=>a.ReservationId==id).Amy()) //Condition to check if data is there or not
              {
                Rdetail.ReservationID = id; 
                Rdetail.Description = MissNote;
                Rdetail.ChargeType = charge;
                db.Insert(Rdetail);
                }
            }
