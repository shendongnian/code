    protected virtual long? GetCurrentOrganizationUnitIdOrNull()
    {
        if (CurrentUnitOfWorkProvider != null &&
            CurrentUnitOfWorkProvider.Current != null)
        {
            return CurrentUnitOfWorkProvider.Current
                .Filters.FirstOrDefault(f => f.FilterName == "MayHaveOrganizationUnit")?
                .FilterParameters["OrganizationUnitId"] as long?;
        }
    
        return ((ICustomAbpSession)AbpSession).OrganizationUnitId;
    }
