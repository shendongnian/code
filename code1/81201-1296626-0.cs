        public static int? ToInt32(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return null;
            int parsed;
            if (Int32.TryParse(input, out parsed))
                return parsed;
            return null;
        }
