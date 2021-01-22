    public static class StringExtensions
    {
        public static string Translate( this string source, string from, string to )
        {
            if (string.IsNullOrEmpty( source ) || string.IsNullOrEmpty( from ))
            {
                return source;
            }
    
            return string.Join( "", source.ToCharArray()
                                       .Select( c => Translate( c, from, to ) )
                                       .Where( c => c != null )
                                       .ToArray() );
        }
    
        private static string Translate( char c, string from, string to )
        {
            int i = from != null ? from.IndexOf( c ) : -1;
            if (i >= 0)
            {
                if (to != null && to.Length > i)
                {
                    return to[i].ToString();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return c.ToString();
            }
        }
    }
