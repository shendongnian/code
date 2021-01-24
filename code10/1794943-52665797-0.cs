    // protected int? CurrentCompanyId = null;
    protected int? CurrentCompanyId => GetCurrentCompanyIdOrNull();
    protected virtual int? GetCurrentTenantIdOrNull()
    {
        if (CurrentUnitOfWorkProvider != null &&
            CurrentUnitOfWorkProvider.Current != null)
        {
            return CurrentUnitOfWorkProvider.Current
                .Filters.FirstOrDefault(f => f.FilterName == "CompanyFilter")?
                .FilterParameters["CompanyId"] as int?;
        }
        return null;
    }
