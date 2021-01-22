        public static string encode(System.Collections.Generic.List<string> data, out string delimiter)
        {
            delimiter = ":";
            while(data.Contains(delimiter)) delimiter += ":";
            return string.Join(delimiter, data.ToArray());
        }
        public static string[] decode(string encoded, string delimiter)
        {
            return encoded.Split(new string[] { delimiter }, StringSplitOptions.None);
        }
