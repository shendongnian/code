    void MyFunction()
    {
        using (TCPSEntities model = new TCPSEntities())
        {
            EmployeeRoles er = model.EmployeeRoles.First(p=>p.EmployeeId == 123);
            er.Roles = GetDefaultRole(model);
            model.SaveChanges();
         }
    }
    private static Roles GetDefaultRole(TCPSEntities model)
    {
        Roles r = null;
        r = model.Roles.First(p => p.RoleId == 1);
        return r;
    }
