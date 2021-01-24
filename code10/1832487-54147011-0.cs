    public IQueryable<Company> getEmpresasVisiblesUsuario(bool onlyActive = true)
    {
         return getEmpresasVisiblesUsuario(db.companies, onlyActive);
    }
    public IQueryable<Company> getEmpresasVisiblesUsuario(IQueryable<Company> companies, bool onlyActive = true)
    {
        int userId = HttpContext.Current.User.Identity.GetUserId<int>();
        companies = companies.Where(s => s.id_user == userId);
    
        if (onlyActive) {
            companies = companies.Where(e => e.active);
        }   
        return companies;
    }
