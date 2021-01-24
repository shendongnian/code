    public ActionResult AddOrEdit(Agency agency, string[] selectedOptions)
    {
        if (agency.id == 0)
        {
            agency.id = _db.Agencies.Count() + 1;
    
            UpdateAgencySectors(selectedOptions, agency);
            _db.Agencies.Add(agency);
            _db.SaveChanges();
            return Json(new {success = true, message = "Saved successfully"}, JsonRequestBehavior.AllowGet);
        }
    
        agency.lastupdated = DateTime.Now;
        _db.Sectors.AddRange(GetAgencySectors(selectedOptions, agency));
        _db.SaveChanges();
        return Json(new {success = true, message = "Updated successfully"}, JsonRequestBehavior.AllowGet);
    }
    private ICollection<Sector> UpdateAgencySectors(string[] selectedOptions, Agency agency)
    {
        List<Sector> sectors = new List<Sector>();
        if (selectedOptions == null)
        {
            return;
        }
    
        var selectedOptionsHs = new HashSet<string>(selectedOptions);
        var agencySectors = new HashSet<int>(agency.Sectors.Select(b => b.id));
        foreach (var sector in _db.Sectors)
        {
            if (selectedOptionsHs.Contains(sector.id.ToString()))
            {
                if (!agencySectors.Contains(sector.id))
                {
                   sectors.Add(sector);
                }
            }
            else
            {
                if (agencySectors.Contains(sector.id))
                {
                    sectors.Remove(sector);
                }
            }
        }
        return sectors;
    }
