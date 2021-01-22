    /// <summary>
    /// Summary description for Helper
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Extension Method For Returning Custom Trim
        /// No Carriage Return or New Lines Allowed
        /// </summary>
        /// <param name="str">Current String Object</param>
        /// <returns></returns>
        public static string CustomTrim(this String str)
        {
            return str.Replace("\r\n", "");
        }
    }
