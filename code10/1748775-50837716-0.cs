    public ActionResult Index(string searchString, string Poison, string Venom)
    {
        var species = db.Species.Include(s => s.Countries);
        if (!String.IsNullOrEmpty(searchString))        
        {   
            species = species.Where(s => s.Countries.Any(c => c.Name.Contains(searchString)));    
        }
    }
