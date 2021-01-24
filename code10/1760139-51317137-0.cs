    var userStore = new UserStore<ApplicationUser>(dbContext);
    List<UsersViewModel> uvml = (from user in userStore.Users
                                     join ext in dbContext.AspNetUsersExtended
                                     on user.X equals ext.X
                                     select new UsersViewModel
                                     {
                                         aspNetUsers = user,
                                         aspUsersExtended = ext
                                     }).ToList();
    return uvml;
