    rowExp[fieldCount] = String.Intern(rowNumExp.ToString()); 
    // Dedup Expected               
    string internedKey = (String.Intern(keyExp.ToString()));        
    if (!(dictExp.ContainsKey(internedKey)))
    {
       dictExp.Add(internedKey, rowExp);                        
    }
    else
    {
       listDupExp.Add(rowExp);
    }  
