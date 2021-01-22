    public override int GetHashCode()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        sb.Append(_dateOfBirth);
        sb.Append(_marital);
        sb.Append(_gender);
        sb.Append(_notes);
        sb.Append(_firstName);
        sb.Append(_lastName);  
            
        return sb.ToString.GetHashCode();
    }
