      public ActionResult Graph(int machineId)
      {
    using (var db = new DatabaseModel())
    {
        var sheets = db.Checksheets
            .Where(s => s.MachineId == machineId)
            .ToList()
            .Select(s => new
            {
                label = $"O: {s.OrderNum} P: {s.PartNum}",
                y = s.GraphPoints
            });
             var sheets1 = db.Checksheets
            .Where(s => s.MachineId == machineId)
            .ToList()
            .Select(s => new
            {
                label = $"O: {s.OrderNum} P: {s.PartNum}",
                y = s.GraphPoints1
            });
             var sheets2 = db.Checksheets
            .Where(s => s.MachineId == machineId)
            .ToList()
            .Select(s => new
            {
                label = $"O: {s.OrderNum} P: {s.PartNum}",
                y = s.GraphPoints2
            });
        return Json(sheets.Concat(sheets1).Concat(sheets2), JsonRequestBehavior.AllowGet);
         }
       }
