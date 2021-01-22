        public static List<string> SplitByMaxLength(this string str)
        {
            List<string> splitString = new List<string>();
            for (int index = 0; index < str.Length; index += MaxLength)
            {
                splitString.Add(str.Substring(index, Math.Min(MaxLength, str.Length - index)));
            }
            return splitString;
        }
