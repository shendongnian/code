      public ActionResult Test(Models.Details[] itemlist)
        {
            foreach (Models.Details d in itemlist)
            {
                guid = Guid.NewGuid();
                d.IdString = guid;
                SessionList.Add(d);
            }
            return Json(new { success = true, id = itemlist[0].IdString, name = itemlist[0].Name, city = itemlist[0].City, country = itemlist[0].Country });
        }
  
