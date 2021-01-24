    public async Task<List<ApplicationUser>> GetApplicationUsersAsync()
    {
        // use Entity Framework properly with ToListAsync
        // this returns the entire table
        return await _context.Users.ToListAsync();
    }
    public async Task<List<StudentViewModel>> GetStudentsAsync()
    {
        // use Entity Framework properly with ToListAsync
        return await _context.Users
            // this only returns the 2 needed properties
            .Select(x => new StudentViewModel
            {
                Forename = x.Forename,
                Surname = x.Surname
            })
            .ToListAsync();
    }
    public async Task<StudentIndexViewModel> CreateStudentRegisterViewModel()
    {
        var model = new StudentIndexViewModel();
        model.Students = await _studentRepo.GetStudentsAsync();
        return model;
    }
