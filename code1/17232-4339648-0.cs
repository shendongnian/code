    namespace Extensions.String
    {
        using System.Text.RegularExpressions;
        public static class Extensions
        {
            /// <summary>
            /// Normalizes whitespace in a string.
            /// Leading/Trailing whitespace is eliminated and
            /// all sequences of internal whitespace are reduced to
            /// a single SP (ASCII 0x20) character.
            /// </summary>
            /// <param name="s">The string whose whitespace is to be normalized</param>
            /// <returns>a normalized string</returns>
            public static string NormalizeWS( this string @this )
            {
                string src        = @this ?? "" ;
                string normalized = rxWS.Replace( src , m =>{
                      bool isLeadingTrailingWS = ( m.Index == 0 || m.Index+m.Length == src.Length ? true : false ) ;
                      string p                 = ( isLeadingTrailingWS ? "" : " " ) ;
                      return p ;
                    }) ;
                return normalized ;
            }
            private static Regex rxWS = new Regex( @"\s+" ) ;
        }
    }
