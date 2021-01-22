    public static bool ContainsIfNotEmptyTrimmed(this string source, string param)
    {
        return !String.IsNullOrEmpty(param.Trim()) && source.Trim().Contains(param.Trim());
    }
    where p.CrookBookUserName.ContainsIfNotEmptyTrimmed(person.CrookBookUserName) || ...
