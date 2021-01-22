    public ActionResult jQueryUserFilter(string filterBy)
    {
        AdminRepository<User> adminRepository = new AdminRepository<User>();
        IQueryable<User> users;
        if (filterBy == "**all**")
            users = adminRepository.All().OrderBy(x => x.userName);
        else
            users = adminRepository.All().Where(u => u.userName.StartsWith(filterBy)).OrderBy(x => x.userName);
        return PartialView("UserList", users);
    }
