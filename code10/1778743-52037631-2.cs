    IQueryable<JOBDEGREEs> jobDegreesQuery = _context.JOBDEGREEs; // it is already queryable
    if (!String.IsNullOrWhiteSpace(name))
        jobDegreesQuery = jobDegreesQuery.Where(c => c.DEGREE_NAME.Contains(name));
    var jobDegreeDTOs = jobDegreesQuery
       //.Select(d=> new {d.DEGREE_CODE,d.DEGREE_NAME }) // do you need this?
       .Select(d => Mapper.Map<JOBDEGREE, JobDegreeDTO>(d)); // here you can give any expression
       .ToList()
           
