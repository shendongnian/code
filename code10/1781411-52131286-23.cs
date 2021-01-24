    [HttpPost]
    public ActionResult Create(MoviesActorsViewModel mcvm)
    {
        _context.mvz.Add(mcvm.mvz);
    
        foreach (var id in mcvm.ids)
        {
            int id1 = Convert.ToInt32(id);
            Actors act = _context.actrs.Find(x => x.Id == id1);
            _context.actrs.Add(act);
        }
    
    
        return RedirectToAction("GetView", "Default");
    }
