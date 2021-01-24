    public ActionResult Create(/*Bind attribute omitted*/ Reservations reservation)
    {
        if (ModelState.IsValid)
        {
            // Is 'IsChecked' nullable? If not, "== true" is redundant.
            var selectedVehicles = reservation.VehicleList.Where(x => x.IsChecked == true).ToList();
            // get each vehicle that was selected to be reserved then check db to make sure it is available
            using (VehicleReservationEntities db = new VehicleReservationEntities())
            {
                foreach (var selectedVehicle in selectedVehicles)
                {
                    // 'alreadyReservedVehicle' can be declared here because you don't need to let it
                    // out of its cage, I mean the loop.
                    List<usp_PreventDoubleBooking_Result> alreadyReservedVehicle =
                        db.usp_PreventDoubleBooking(selectedVehicle.ID, reservation.StartDate, reservation.EndDate).ToList();
                    if (alreadyReservedVehicle.Count() > 0)
                    {
                        //return error message on page if vehicle is already reserved
                        TempData["Error"] = "Double booking of vehicles is not allowed. Please choose another vehicle/time. Check the availability timeline before reserving to ensure there are no errors. Thank you.";
                        return RedirectToAction("Create");
                    }
                }
            }
            // create a new reservation if the vehicle is available at the selected date and time
            db.Reservations.Add(reservation);
            reservation.LastChangedDate = DateTime.Now;
            db.SaveChanges();
        }
    }
