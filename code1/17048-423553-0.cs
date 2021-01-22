    // Values ordered true/false
    // True/false values separated by a capital letter
    // Only two values allowed
    // ---------------------------
    // Limited, but could be useful
    public enum BooleanFormat
    {
        OneZero,
        YN,
        YesNo,
        TF,
        TrueFalse,
        PassFail,
        YepNope
    }
    
    public static class BooleanExtension
    {
        /// <summary>
        /// Converts the boolean value of this instance to the specified string value. 
        /// </summary>
        private static string ToString(this bool value, string passValue, string failValue)
        {
            return value ? passValue : failValue;
        }
        
        /// <summary>
        /// Converts the boolean value of this instance to a string. 
        /// </summary>
        /// <param name="booleanFormat">A BooleanFormat value. 
        /// Example: BooleanFormat.PassFail would return "Pass" if true and "Fail" if false.</param>
        /// <returns>Boolean formatted string</returns>
        public static string ToString(this bool value, BooleanFormat booleanFormat)
        {
            string booleanFormatString = Enum.GetName(booleanFormat.GetType(), booleanFormat);
            return ParseBooleanString(value, booleanFormatString);      
        }
        // Parses boolean format strings, not optimized
        private static string ParseBooleanString(bool value, string booleanFormatString)
        {
            StringBuilder trueString = new StringBuilder();
            StringBuilder falseString = new StringBuilder();
            int charCount = booleanFormatString.Length;
            bool isTrueString = true;
            for (int i = 0; i != charCount; i++)
            {
                if (char.IsUpper(booleanFormatString[i]) && i != 0)
                    isTrueString = false;
                if (isTrueString)
                    trueString.Append(booleanFormatString[i]);
                else
                    falseString.Append(booleanFormatString[i]);
            }
            return (value == true ? trueString.ToString() : falseString.ToString());
        }
