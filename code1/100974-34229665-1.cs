    // System.Web.Util.HashCodeCombiner.CombineHashCodes(System.Int32, System.Int32): http://referencesource.microsoft.com/#System.Web/Util/HashCodeCombiner.cs,21fb74ad8bb43f6b
    // System.Array.CombineHashCodes(System.Int32, System.Int32): http://referencesource.microsoft.com/#mscorlib/system/array.cs,87d117c8cc772cca
    public static int CombineHashCodes(IEnumerable<int> hashCodes)
    {
        int hash = 5381;
    
        foreach (var hashCode in hashCodes)
            hash = ((hash << 5) + hash) ^ hashCode;
    
        return hash;
    }
