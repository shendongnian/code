    var userId = new Guid(_userManager.GetUserId(User));
    var files = _dbContext.Files
                   .Include(p => p.Project)
                   .ThenInclude(up => up.UserProjects)
                   .ThenInclude(u => u.User)
                   .Where(x => x.Project.UserProjects.User.Id == userId)
                   .ToList();
