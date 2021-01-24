    public void Add(Admin admin)
    {
        var admins = GetAll():
        var val = new AdminValidator(admins);
        validator.ValidateAndThrow(admin);
         _adminDal.Add(admin);
    }
