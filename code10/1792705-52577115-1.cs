    //in IsoFileApplicationType.cs
    public IsoFileApplicationType(IsoFileApplicationType isoFileApplicationType)
    {
        Id = null
        FullName = isoFileApplicationType.FullName;
        Name = isoFileApplicationType.Name;
        (...)
      
    
        foreach (IsoTableData isoTableData in isoFileApplicationType.IsoTableData)
        {
            IsoTableData.Add(IsoTableData(isoTableData));
        }
    }
    
    //in IsoTableData.cs
    public IsoTableData(IsoTableData isoTableData)
    {
        Id = null;
        Data = isoTableData.Name;
        Age = isoTableData.Age;
        (...)
    }
        
    // in CRUD controller
    var applicationType = await _context.ApplicationType
                                       .Include(m => m.IsoTableData)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(m => m.Id == id);
        
    if (applicationType == null)
    {
        return NotFound();
    }
    IsoFileApplicationType newIsoFileApplicationType = IsoFileApplicationType(applicationType);
    return Ok(newIsoFileApplicationType);
