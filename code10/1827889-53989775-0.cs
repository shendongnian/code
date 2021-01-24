    /// <summary>
        /// Converts a string to a properly formatted text. Includes correcting single quotes.
        /// </summary>
        /// <param name="Field">String to format</param>
        /// <returns></returns>
        internal static String SQLString(object Field)
        {
            String s = "";
            try
            {
                s = Convert.ToString(Field);
            }
            catch
            { }
            return "'" + s.Replace("'", "''").Replace("\r\n", "' || chr(10) || '").Trim() + "'";
        }
