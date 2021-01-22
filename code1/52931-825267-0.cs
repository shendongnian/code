    public bool Match(string str)
    {
        return string.IsNullOrEmpty(str)
                   || str.ToCharArray()
                         .Skip(1)
                         .Any( c => !c.Equals(str[0]) );
    }
