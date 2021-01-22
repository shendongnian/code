    class Program {
        static void Main( string[] args ) {
            string unicodeString = "This function contains a unicode character pi (\u03a0)";
            Console.WriteLine( unicodeString );
            string encoded = EncodeNonAsciiCharacters(unicodeString);
            Console.WriteLine( encoded );
            string decoded = DecodeEncodedNonAsciiCharacters( encoded );
            Console.WriteLine( decoded );
        }
        static string EncodeNonAsciiCharacters( string value ) {
            StringBuilder sb = new StringBuilder();
            foreach( char c in value ) {
                if( c > 127 ) {
                    // This character is too big for ASCII
                    sb.AppendFormat( "\\u{0:x4}", (uint) c );
                }
                else {
                    sb.Append( c );
                }
            }
            return sb.ToString();
        }
        static string DecodeEncodedNonAsciiCharacters( string value ) {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m => {
                    return ((char) int.Parse( m.Groups["Value"].Value, NumberStyles.HexNumber )).ToString();
                } );
        }
    }
