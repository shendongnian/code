    public int GetHashCode()
    {
        int hash = 17;
        // Suitable nullity checks etc, of course :)
        hash = hash * 23 + StreetAddress.GetNullSafeHashCode();
        hash = hash * 23 + RuralRoute.GetNullSafeHashCode();
        hash = hash * 23 + City.GetNullSafeHashCode();
        hash = hash * 23 + Province.GetNullSafeHashCode();
        hash = hash * 23 + Country.GetNullSafeHashCode();
        hash = hash * 23 + PostalCode.GetNullSafeHashCode();
        return hash;
    }
