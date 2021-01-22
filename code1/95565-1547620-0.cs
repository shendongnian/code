    StringBuilder sb = new StringBuilder();
    
    for (int i = 0; i < list.Count; i++)
    {
        string rowValue = list[iRow];
        if (!string.IsNullOrEmpty(rowValue))
        {
            sb.Append(rowValue);
            sb.Append(", ");
        }    
    }
    
    // use sb.ToString() to obtain result
