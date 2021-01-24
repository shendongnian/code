    public List<string> GetMemberNames<T1, T2>(IEnumerable<string> propNames)
    {
        var commonProps = (from pn in propNames
                           where
                           typeof(T1).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                     .Any(p => p.Name == pn) ||
                           typeof(T2).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                     .Any(p => p.Name == pn)
                           select pn).ToList();
    
        return commonProps;
    }
