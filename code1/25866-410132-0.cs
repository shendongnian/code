    string[] GetArray(string input)
    {
        string[] vals = input.Split(',');
    
        List<string> entries = new List<string>();
    
        string s;
        for(int i=vals.Length - 1; i > 0; i--)
        {
            s = vals[i];
    
            if(i < vals.Length - 1)
               s += "," +  vals[i+1];
            
            entries.Add(s);
        }
    
       return entries.ToArray();
    }
