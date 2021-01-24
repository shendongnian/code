    public IEnumerable<ListofModuleUser> LoadData()
    {
        using (var ctx = new JEntities())
        {
            return (from mu in ctx.tblModuloUsers.AsQueryable()
                    join u in ctx.tblUsers on mu.UserID equals u.UserID
                    join m in ctx.tblModuloes on mu.ModuloID equals m.ModuloID
                    select new ListofModuleUser
                    {
                        User = u.Username,
                        Modulo = m.Moduloname,
                        Read = mu.CanRead,
                        Write = mu.CanWrite,
                        Create = mu.CanCreate,
                        Delete = mu.CanDelete,
                        Navigate = mu.CanNavigate
                     })
                     .ToList();
        }
    }
