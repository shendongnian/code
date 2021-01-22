        using System.Text.RegularExpressions;
        using System.ComponentModel;
        public static string StringWithFormat(string format, object args)
        {
            Regex r = new Regex(@"\{([A-Za-z0-9_]+)\}");
            MatchCollection m = r.Matches(format);
            var properties = TypeDescriptor.GetProperties(args);
            foreach (Match item in m)
            {
                try
                {
                    format = format.Replace(item.Value, properties[item.Groups[1].Value].GetValue(args).ToString());
                }
                catch
                {
                    throw new FormatException("The format string is not valid");
                }
            }
            return format;
        }
