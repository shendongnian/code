        /// <summary>
        /// !#$345Hf} → %21%23%24%33%34%35%48%66%7D
        /// </summary>
        public static string UrlEncodeExtended( string value )
        {
            char[] chars = value.ToCharArray();
            StringBuilder encodedValue = new StringBuilder();
            foreach (char c in chars)
            {
                encodedValue.Append( "%" + ( (int)c ).ToString( "X2" ) );
            }
            return encodedValue.ToString();
        }
