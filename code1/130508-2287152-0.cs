    var sb = new StringBuilder(19);
    sb.Append(s,0,4);
    for(var i = 1; i < 4; i++ )
    {
     sb.Append('-');
     sb.Append(s,i*4, 4);
    }
    return sb.ToString();
