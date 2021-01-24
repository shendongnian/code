    // ** Return type is the projected result
    public async Task<IEnumerable<Department>> GetAllDepartmentBySchoolIdAsync(int schoolId) // ** async
    {
        var school = await _GpsContext.School // ** await 
           .Where(s => s.ID == schoolId)
           .FirstOrDefaultAsync(); 
        if (school == null)
            return Enumerable.Empty<Department>(); // Avoid returning nulls
        var departments = await _GpsContext.DepartmentSchool // ** await
            .Where(ds => ds.SchoolsId == schoolId)
            .SelectMany(ds => ds.Department) // ** flatten and project the navigation property
            .ToListAsync(); // ** materialize
        return departments; // ** Don't use Http stuff like OK in Repo layer
    }
