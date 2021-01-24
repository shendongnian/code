    [HttpPost]
    Public ActionResult Create(Guid? Id, Car model)
    {
        If(ModelState.IsValid)
        {
           bookingList=GetBookings();
           model.Id= Id ?? Guid.NewGuid();
           bookingList.Add(model);
           TempData["bookingList"]= bookingList;
           
           return RedirectToAction("Index");
        }
       
        return View(model);
        }
    }
