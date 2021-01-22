    public IEnumerable<ISite> GetSites()
    {
        return Db.Sites.Select(x => new { x.id, x.name }) // Project in SQL
                       .AsEnumerable() // Do the rest in process
                       .Select(x => new cms.bo.Site(x.id, x.name))
                       .Cast<ISite>(); // Workaround for lack of covariance
    }
