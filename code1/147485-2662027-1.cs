        public static class StringEscape
        {
            public static string EscapeStringChars( this string txt )
            {
                if ( string.IsNullOrEmpty( txt ) ) return txt;
                StringBuilder retval = new StringBuilder( txt.Length*2 );
                for ( int ix = 0; ix < txt.Length; )
                {
                    int jx = txt.IndexOf( '\\', ix );
                    if ( jx < 0 || jx == txt.Length - 1 ) jx = txt.Length;
                    retval.Append( txt, ix, jx-ix );
                    if ( jx >= txt.Length ) break;
                    switch ( txt[jx + 1] )
                    {
                        case 'n': retval.Append( '\n' ); break;  // Line feed
                        case 'r': retval.Append( '\r' ); break;  // Carriage return
                        case 't': retval.Append( '\t' ); break;  // Tab
                        case '\\': retval.Append( '\\' ); break; // Don't escape
                        default:                                 // Unrecognized, copy as-is
                            retval.Append( '\\' ).Append( txt[jx + 1] ); break;
                    }
                    ix = jx + 2;
                }
                return retval.ToString();
            }
        }
