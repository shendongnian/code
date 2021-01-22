        public static String Substring(this String val, int startIndex, bool handleIndexException)
        {
            if (!handleIndexException)
            { //handleIndexException is false so call the base method
                return val.Substring(startIndex);
            }
            if (string.IsNullOrEmpty(val))
            {
                return val;
            }
            return val.Substring(startIndex < 0 ? 0 : startIndex > (val.Length - 1) ? val.Length : startIndex);
        }
        public static String Substring(this String val, int startIndex, int length, bool handleIndexException)
        {
            if (!handleIndexException)
            { //handleIndexException is false so call the base method
                return val.Substring(startIndex, length);
            }
            if (string.IsNullOrEmpty(val))
            {
                return val;
            }
            int newfrom, newlth, instrlength = val.Length;
            if (length < 0) //length is negative
            {
                newfrom = startIndex + length;
                newlth = -1 * length;
            }
            else //length is positive
            {
                newfrom = startIndex;
                newlth = length;
            }
            if (newfrom + newlth < 0 || newfrom > instrlength - 1)
            {
                return string.Empty;
            }
            if (newfrom < 0)
            {
                newlth = newfrom + newlth;
                newfrom = 0;
            }
            return val.Substring(newfrom, Math.Min(newlth, instrlength - newfrom));
        }
