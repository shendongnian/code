    [HttpPost]
    public ActionResult Createslots(Slot slot)
    {
      using (MYDb db = new MYDb())
      {
        db.Slots.Add(slot);
        db.SaveChanges();
      }
      //return to whatever
    }
