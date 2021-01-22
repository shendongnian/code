    static public class StringFormat
    {
        static private char[] separator = new char[] { ':' };
        static private Regex findParameters = new Regex(
            "\\{(?<param>.*?)\\}",
            RegexOptions.Compiled | RegexOptions.Singleline);
        static string FormatNamed(
            this string format,
            Dictionary<string, object> args)
        {
            return findParameters.Replace(
                format,
                delegate(Match match)
                {
                    string[] param = match.Groups["param"].Value.Split(separator, 2);
                    object value;
                    if (!args.TryGetValue(param[0], out value))
                        value = match.Value;
                    if ((param.Length == 2) && (param[1].Length != 0))
                        return string.Format(
                            CultureInfo.CurrentCulture,
                            "{0:" + param[1] + "}",
                            value);
                    else
                        return value.ToString();
                });
        }
    }
