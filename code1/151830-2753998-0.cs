    public override bool IsValid(object value)
    {
        string str = Convert.ToString(value, CultureInfo.CurrentCulture);
        if (string.IsNullOrEmpty(str))
        {
            return true;
        }
        Match match = this.Regex.Match(str);
        return ((match.Success && (match.Index == 0)) && (match.Length == str.Length));
    }
    
