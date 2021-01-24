    [HttPost]
    public ActionResult Createslots(Slot mySlot)
    {
        using (MYDb db = new MYDb())
        {
            Slot obj = new Slot();
            obj.Starttime = Convert.ToDateTime(mySlot.StartTime);
            obj.EndTime = Convert.ToDateTime(mySlot.EndTime);
            obj.DateSlots = mySlot.DateSlots;
            db.Slots.Add(obj);
            db.SaveChanges();
        }
        return View();
    }
