        /// <summary>
        /// Formats the log entry.
        /// /// Taken from:
        /// http://stackoverflow.com/questions/561125/can-i-pass-parameters-to-string-format-without-specifying-numbers
        /// and adapted to WINRT
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">The string format is not valid</exception>
        public static string FormatLogEntry(string format, object args)
        {
            Regex r = new Regex(@"\{([A-Za-z0-9_]+)\}");
            MatchCollection m = r.Matches(format);
            var properties = args.GetType().GetTypeInfo().DeclaredProperties;
            foreach (Match item in m)
            {
                try
                {
                    string propertyName = item.Groups[1].Value;
                    format = format.Replace(item.Value, properties.Where(p=>p.Name.Equals(propertyName))
                    .FirstOrDefault().GetValue(args).ToString());
                }
                catch
                {
                    throw new FormatException("The string format is not valid");
                }
            }
            return format;
        }
