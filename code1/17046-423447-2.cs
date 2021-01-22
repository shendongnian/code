    print("code sample");
        /// <summary>
        /// Calls the underlying int.TryParse method to convert a string representation of a number to its 32-bit signed integer equivalent. Returns Zero if conversion fails. 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>returns 0 if the conversion fails</returns>
        public static int ToInt32(this string s)
        {
            int retInt;
            bool b = int.TryParse(s, out retInt);
            return retInt;
        }    
