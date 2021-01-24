    [HttpGet]
    public IEnumerable<Project> GetProjects()
    {
        return _context.Projects.Include(p => p.Tasks).ToList();
    }
