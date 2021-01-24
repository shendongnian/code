    public ActionResult Create(int id)
    {
        var bookings = db.Bookings.Include(b => b.Room).Include(b => b.Register);
        var model = new ViewModel();
        // use query to get both selected IDs
        model.RoomId = bookings.Where(...).Select(x => x.RoomId).FirstOrDefault();
        model.CustomerId = bookings.Where(...).Select(x => x.CustomerId).FirstOrDefault();
        model.RoomList = db.Rooms.Select(x => new SelectListItem { Text = x.RoomType, Value = x.RoomID }).ToList();
        model.CustomerList = db.Registers.Select(x => new SelectListItem { Text = x.username, Value = x.id }).ToList();
        return View(model);
    }
