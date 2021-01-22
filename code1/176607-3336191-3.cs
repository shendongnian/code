    StringBuilder stringBuilder = new StringBuilder();
    int i = 0;
    foreach (var guid in guids)
    {
        stringBuilder.Append(guid.ToString());
        if (++i < guids.Length)
        { 
            stringBuilder.Append(","); 
        }
    }
    
    var str = stringBuilder.ToString();
