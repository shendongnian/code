        public static string SafeFormat(this string fmt, params object[] args)
        {
            string formattedString = fmt;
            try
            {
                formattedString = String.Format(fmt, args);
            }
            catch (FormatException) {} //logging string arguments were not correct
            return formattedString;
        }
