    public IQueryable<FACILITY_ITEM> GetFacilityItemRootByDescription(string description)
        {
                return this.ObjectContext.FACILITY_ITEM
                           .Where(fi => fi.DESCRIPTION
                           .Equals(description, StringComparison.OrdinalIgnoreCase));
        }
