           [HttpGet]
           public ActionResult FlightBoardingDisplay()
          {
            string date = String.Format("{0:D}", DateTime.Now.Date);
            ViewBag.Date = date;
            return PartialView(db.tblFlightSchedules.OrderBy(m => m.Time).Where(m => m.Origin == 
            "KATHMANDU").ToList());
       }
     
    [HttpGet]
    public ActionResult FlightStatusDisplay()
    {
        string date = String.Format("{0:D}", DateTime.Now.Date);
        ViewBag.Date = date;
        return PartialView(db.tblFlightSchedules.OrderBy(m => m.Time).Where(m => m.Origin == "KATHMANDU").Where(m => m.FSId == 4).Where(m=>m.FSId ==1).Where(m=>m.FSId==3).ToList());
    }
