    public ActionResult Details(int? id)
    {
        if (id != null)
        {
            var result = (from a in db.aTable
                          join b in db.bTable on a.carID equals b.bID
                          where a.aID == id.Value
                          select new ModifiedaTableModel
                          {
                              aID = a.aID,
                              aName = a.aName,
                              carName = b.bcarName
                          }).SingleOrDefault();
        }
        return View(result);
    }
