    public sealed class HexEncoding : Encoding
    {
        public static readonly HexEncoding Hex = new HexEncoding( );
        private static readonly char[] HexAlphabet;
        private static readonly byte[] HexValues;
        static HexEncoding( )
        {
            HexAlphabet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            HexValues = new byte[255];
            for ( int i = 0 ; i < HexValues.Length ; i++ ) {
                char c = (char)i;
                if ( "0123456789abcdefABCDEF".IndexOf( c ) > -1 ) {
                    HexValues[i] = System.Convert.ToByte( c.ToString( ), 16 );
                }   // if
            }   // for
        }
        public override string EncodingName
        {
            get
            {
                return "Hex";
            }
        }
        public override bool IsSingleByte
        {
            get
            {
                return true;
            }
        }
        public override int GetByteCount( char[] chars, int index, int count )
        {
            return count / 2;
        }
        public override int GetBytes( char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex )
        {
            int ci = charIndex;
            int bi = byteIndex;
            while ( ci < ( charIndex + charCount ) ) {
                char c1 = chars[ci++];
                char c2 = chars[ci++];
                byte b1 = HexValues[(int)c1];
                byte b2 = HexValues[(int)c2];
                bytes[bi++] = (byte)( b1 << 4 | b2 );
            }   // while
            return charCount / 2;
        }
        public override int GetCharCount( byte[] bytes, int index, int count )
        {
            return count * 2;
        }
        public override int GetChars( byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex )
        {
            int ci = charIndex;
            int bi = byteIndex;
            while ( bi < ( byteIndex + byteCount ) ) {
                int b1 = bytes[bi] >> 4;
                int b2 = bytes[bi++] & 0xF;
                char c1 = HexAlphabet[b1];
                char c2 = HexAlphabet[b2];
                chars[ci++] = c1;
                chars[ci++] = c2;
            }   // while
            return byteCount * 2;
        }
        public override int GetMaxByteCount( int charCount )
        {
            return charCount / 2;
        }
        public override int GetMaxCharCount( int byteCount )
        {
            return byteCount * 2;
        }
    }   // class
