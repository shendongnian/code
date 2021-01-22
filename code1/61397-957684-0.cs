    public int GetHashCode()
    {
        int hash = 17;
        // Suitable nullity checks etc, of course :)
        hash = hash * 23 + StreetAddress.GetHashCode();
        hash = hash * 23 + RuralRoute.GetHashCode();
        hash = hash * 23 + City.GetHashCode();
        hash = hash * 23 + Province.GetHashCode();
        hash = hash * 23 + Country.GetHashCode();
        hash = hash * 23 + PostalCode.GetHashCode();
        return hash;
    }
