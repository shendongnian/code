        public static string CapitalizeFirstLetter(this String input)
        {
            if (string.IsNullOrEmpty(input)) 
                return input;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
