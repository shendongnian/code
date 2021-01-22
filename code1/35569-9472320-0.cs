    using System.Text.RegularExpressions;
    using System.ComponentModel;
    public static string StringWithParameter(string format, object args)
        {
            Regex r = new Regex(@"\{([A-Za-z0-9_]+)\}");
            MatchCollection m = r.Matches(format);
            var properties = TypeDescriptor.GetProperties(args);
            foreach (Match item in m)
            {
                try
                {
                    string propertyName = item.Groups[1].Value;
                    format = format.Replace(item.Value, properties[propertyName].GetValue(args).ToString());
                }
                catch
                {
                    throw new FormatException("The string format is not valid");
                }
            }
            return format;
        }
