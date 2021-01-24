    string encryptedPassword = AesEncryptAndDecrypt.EncryptString(userView.Password, crytograpyKey, crytograpyIV);
    var userData = await _adminGenericRepository.FindBy(x => x.IsActive && x.UserName == userView.UserName && x.Password == encryptedPassword)
        .Select( new     
        {
            UserId = user.UserId,
            IsActive = user.IsActive,
            UserName = user.UserName,
            LastName = user.LastName,
            FirstName = user.FirstName,
            // When using FirstOrDefault, you should have an OrderBy to ensure the selection is predictable.
            SelectedRole = user.RoleAssign.OrderByDescending(x => x.Date).FirstOrDefault()?.Role 
            // Cannot call C# methods here since this will go to SQL.. 
            // If you can populate a UserRoleViewModel in-line, then that can be put here to skip the extra mapping below.
        }).SingleOrDefaultAsync();
    
    // At this point we will have the user details and it's selected Role ready for mapping. 
    //This assumes that the mapping of the Role does not rely on any child relationships under the Role.
    if (userData != null)
        return new UserViewModel
        {
            UserId = userData.UserId,
            IsActive = userData.IsActive,
            UserName = userData.UserName,
            LastName = userData.LastName,
            FirstName = userData.FirstName,
            SelectedRole = mapRoleDbDataToViewModel(userData.SelectedRole)
        };
    else
        return null;
