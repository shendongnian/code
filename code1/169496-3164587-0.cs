        private static System.ComponentModel.TypeConverter colorConv = System.ComponentModel.TypeDescriptor.GetConverter(System.Drawing.Color.Red);
        /// <summary>
        /// Parse a string to a Color
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static System.Drawing.Color ColorFromString(string txt)
        {
            try
            {
                object tmp = colorConv.ConvertFromString(txt);
                return (tmp is System.Drawing.Color) ? (System.Drawing.Color)tmp : System.Drawing.Color.Empty;
            }
            catch 
            {
                // Failed To Parse String
                return System.Drawing.Color.Empty;
            }
        }
