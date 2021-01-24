        public ActionResult Create(int id)
        {
            var bookings = db.Bookings.Include(b => b.Room).Include(b => b.Register);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomType", id);
            ViewBag.CustomerID = new SelectList(db.Registers, "id", "username");
            return View();
        }
