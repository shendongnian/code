    public override int GetHashCode() // or call it GetChangeHash or somthing if you dont want to override the GetHashCode function...
    {
        var sb = new System.Text.StringBuilder();
        
        sb.Append(_dateOfBirth);
        sb.Append(_marital);
        sb.Append(_gender);
        sb.Append(_notes);
        sb.Append(_firstName);
        sb.Append(_lastName);  
            
        return sb.ToString.GetHashCode();
    }
