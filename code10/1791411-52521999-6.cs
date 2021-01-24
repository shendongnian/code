    using (Context context = new Context())
    {
        var company = context.Companies.Where(x => x.id == someCompanyId)
                                       .Include(g => g.Services)
                                       .Include(g => g.Containers)
                                       .Include(g => g.Containers.Select(s => s.Services))
                                       .ToList();
    }
