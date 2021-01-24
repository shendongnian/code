    // using Abp.Collections.Extensions;
    // protected int? CurrentCompanyId = null;
    protected int? CurrentCompanyId => GetCurrentCompanyIdOrNull();
    protected virtual int? GetCurrentCompanyIdOrNull()
    {
        if (CurrentUnitOfWorkProvider != null &&
            CurrentUnitOfWorkProvider.Current != null)
        {
            return CurrentUnitOfWorkProvider.Current
                .Filters.FirstOrDefault(f => f.FilterName == "CompanyFilter")?
                .FilterParameters.GetOrDefault("CompanyId") as int?;
        }
        return null;
    }
