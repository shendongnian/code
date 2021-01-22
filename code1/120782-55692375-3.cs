    using System.Collections.Generic;
    using System.Text;
    ........
    public static string GetCommonPrefix ( IList<string> strings )
    {
        var stringsCount = strings.Count;
        if( stringsCount == 0 )
            return null;
        if( stringsCount == 1 )
            return strings[0];
        var sb = new StringBuilder( strings[0] );
        string str;
        int i, j, sbLen, strLen;
        for( i = 1; i < stringsCount; i++ )
        {
            str = strings[i];
            sbLen = sb.Length;
            strLen = str.Length;
            if( sbLen > strLen )
                sb.Length = sbLen = strLen;
            for( j = 0; j < sbLen; j++ )
            {
                if( sb[j] != str[j] )
                {
                    sb.Length = j;
                    break;
                }
            }
        }
        return sb.ToString();
    }
