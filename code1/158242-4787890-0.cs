    public static class StringExtensions
    {
        /// <summary>
        /// Takes a negative integer - counts back from the end of the string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        public static string SubstringReverse(this string str, int length)
        {
            if (length > 0) 
            {
                throw new ArgumentOutOfRangeException("Length must be less than zero.");
            }
            if (str.Length < Math.Abs(length))
            {
                throw new ArgumentOutOfRangeException("Length cannot be greater than the length of the string.");
            }
           
            return str.Substring((str.Length + length), Math.Abs(length));
        }
    }
}
