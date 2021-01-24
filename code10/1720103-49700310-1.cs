    // controller
    public IEnumerable<Father> GetFathers()
    {
        return db.Father.ToList().Select(f => new Father
        { 
           name = f.name, 
           familyName = new FamilyName { name = f.familyName.name }
        });
    }
