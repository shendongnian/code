    foreach(int id in chkId.Select(x => int.Parse(x))
    {
      var general = new General { IID = id };
      db.Generals.Attach(general);
      db.Generals.Remove(general);
    }
    db.SaveChanges();
