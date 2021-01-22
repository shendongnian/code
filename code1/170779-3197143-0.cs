    StringBuilder sb = new StringBuilder();
    for(int i=0; i<s.Length; i++)
    {
        // exclude spaces preceeded by a letter and succeeded by a number
        if(!(s[i] == ' '
            && i-1 >= 0 && IsLetter(s[i-1])
            && i+1 < s.Length && IsNumber(s[i+1])))
        {
            sb.Append(s[i]);
        }
    }
    return sb.ToString();
