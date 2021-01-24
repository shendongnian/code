    public IQueryable<Object> GetArtists()
    {
        return from a in db.Artists
                join p in db.Projects on a.ArtistID equals p.ArtistID into artistProjects
                select new
                {
                    name = a.ArtistName,
                    projects = artistProjects.Select(ap => ap.ProjectName)
                };
    }
    
