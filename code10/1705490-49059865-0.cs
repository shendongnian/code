    foreach (var item in (db.Links.Where(c => c.IdentifierID == identifier.ID)).ToList())
    {
      db.Links.Remove(item);
      db.SaveChanges();
    }
