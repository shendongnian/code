        public static void PrintCultureDateTime(string culture)
        {
            string result = new DateTime(2017, 10, 1).ToString(FixedSizeShortDatePattern(culture));
            Console.WriteLine(string.Format("{0}: {1}", culture, result));
        }
        public static string FixedSizeShortDatePattern(string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            string format = cultureInfo.DateTimeFormat.ShortDatePattern;
            return ReplaceSingleChar(ReplaceSingleChar(format, 'd'), 'M');
        }
        public static string ReplaceSingleChar(string input, char c)
        {
            string cStr = c.ToString();
            string strRegex = string.Format(@"^({0})[^{0}]|[^{0}]({0})[^{0}]|[^{0}]({0})$", cStr);
            return Regex.Replace(input, strRegex, (match) =>
            {
                string token = match.Groups[0].Value;
                if (!string.IsNullOrEmpty(token))
                {
                    return match.Value.Replace(cStr, string.Concat(cStr, cStr));
                }
                return token;
            });
        }
