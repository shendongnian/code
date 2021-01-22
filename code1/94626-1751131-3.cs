    public IQueryable< EmployeDTO > EmployesDTO(string strPRENOM, string strNOM)
    {
        var query = this.Context.EMPLOYEs.AsQueryable();
        if (!String.IsNullOrEmpty(strPRENOM)) query = query
                  .Where(e => e.PRENOM.Contains(strPRENOM));
        if (!String.IsNullOrEmpty(strNOM)) query = query
                  .Where(e => e.NOM.Contains(strNOM));
       return from emp in query  select ( 
                   new EmployeDTO () {
                       ID = emp.ID,
                       Prenom = emp.Prenom, 
                       Nom = emp.Nom
                   });             
    }
