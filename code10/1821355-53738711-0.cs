    public ActionResult Create(int id)
    {
        var bookings = db.Bookings.Include(b => b.Room).Include(b => b.Register);
        var model = new ViewModel();
        // use query to get both selected IDs
        model.RoomId = bookings.Where(...).Select(x => x.RoomId).FirstOrDefault();
        model.CustomerId = bookings.Where(...).Select(x => x.CustomerId).FirstOrDefault();
        ViewBag.RoomList = new SelectList(db.Rooms, "RoomID", "RoomType");
        ViewBag.CustomerList = new SelectList(db.Registers, "id", "username");
        return View(model);
    }
