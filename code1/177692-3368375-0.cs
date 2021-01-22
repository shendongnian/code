    public IQueryable<FACILITY_ITEM> GetFacilityItemRootByDescription(string description)
    {
        return this.ObjectContext.FACILITY_ITEM
            .Where(fi => fi.DESCRIPTION
                           .IndexOf(description, StringComparison.OrdinalIgnoreCase) != -1);
    }
