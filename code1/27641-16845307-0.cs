        /// <summary>
        /// Extension method that works out if a string is numeric or not
        /// </summary>
        /// <param name="str">string that may be a number</param>
        /// <returns>true if numeric, false if not</returns>
        public static bool IsNumeric(this String str)
        {
            double myNum = 0;
            if (Double.TryParse(str, out myNum))
            {
                return true;
            }
            return false;
        }
