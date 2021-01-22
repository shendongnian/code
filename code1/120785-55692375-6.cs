    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    ........
    public static string GetCommonPrefixParallel ( IList<string> strings )
    {
        var stringsCount = strings.Count;
        if( stringsCount == 0 )
            return null;
        if( stringsCount == 1 )
            return strings[0];
        var firstStr = strings[0];
        var finalList = new List<string>();
        var finalListLock = new object();
        Parallel.For( 1, stringsCount,
            () => new StringBuilder( firstStr ),
            ( i, loop, localSb ) =>
            {
                var sbLen = localSb.Length;
                var str = strings[i];
                var strLen = str.Length;
                if( sbLen > strLen )
                    localSb.Length = sbLen = strLen;
                for( int j = 0; j < sbLen; j++ )
                {
                    if( localSb[j] != str[j] )
                    {
                        localSb.Length = j;
                        break;
                    }
                }
                return localSb;
            },
            ( localSb ) =>
            {
                lock( finalListLock )
                {
                    finalList.Add( localSb.ToString() );
                }
            } );
        return GetCommonPrefix( finalList );
    }
