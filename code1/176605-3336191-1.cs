    StringBuilder stringBuilder = new StringBuilder();
    foreach (var guid in guids)
    {
        stringBuilder.Append(guid.ToString());
        if (i < guids.Length)
        { 
            stringBuilder.Append(","); 
        }
        i++;
    }
    
    var str = stringBuilder.ToString();
