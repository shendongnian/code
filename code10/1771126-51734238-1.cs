     public ActionResult Parts()
    {
       CompositeModel model = new CompositeModel
       {
         Transaction = new Transaction();
         ListOfParts = db.Part.ToList();
       };
       return View(model);
    }
