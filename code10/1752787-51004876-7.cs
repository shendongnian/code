    public IQueryable<Object> GetArtists()
    {
        return db.Artists
                .Include(a => a.Projects)
                .Select(a => 
                    new
                    {
                        name = a.ArtistName,
                        projects = a.Projects.Select(p => p.ProjectName)
                    });
    }
