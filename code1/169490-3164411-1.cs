    StringBuilder sb = new StringBuilder();
        
    foreach (MySampleClass c in dictSampleClass)
    {
        sb.Append(c.VAR1);
        sb.Append(c.VAR2);
        sb.Append(c.VAR3);
        sb.Append("|");
    }
        
    string[] results = sb.ToString().Split('|');
        
    for (int i = 0; i < dictSampleClass.Count; i++)
    {
        string s = results[i];
        MySampleClass c = dictSampleClass[i];
        PerformSomeTask(s,c.VAR4); 
    }
