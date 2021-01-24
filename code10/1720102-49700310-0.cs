    // controller
    public object GetFathers()
    {
        return db.Father.Select(f => new 
        { 
           name = f.name, 
           familyName = new { name = f.familyName.name }
        });
    }
