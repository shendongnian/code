        /// <summary>
        /// kind of a dopey little one-off for StringBuffer, but 
        /// an example where you can get crazy with extension methods
        /// </summary>
        public static void Prepend(this StringBuilder sb, string s)
        {
            sb.Insert(0, s);
        }
