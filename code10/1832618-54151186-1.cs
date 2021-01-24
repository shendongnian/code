    [HttpPost]
    public ActionResult Edit2(ReservationVM reservationVM)
    {
        if (ModelState.IsValid)
        {
            // Here access the necessary values you need from `reservationVM` and do your necessary stuffs
            return RedirectToAction("Index");
        }
        return View(reservation);
    }
