    public static class StringExtensions
    {
        public static string BindTo<T>(this string body, T model) where T : class
        {
            Regex regex = new Regex(@"{([a-zA-Z]+[0-9]*)}");
            var matches = regex.Matches(body).Cast<Match>()
                .OrderByDescending(i => i.Index);
            foreach (Match match in matches)
            {
                var fullMatch = match.Groups[0];
                var propName = match.Groups[1].Value;
                object value = string.Empty;
                try
                {
                    // use reflection to get property
                    // Note: if you need to use fields use GetField
                    var prop = typeof(T).GetProperty(propName);
                    if (prop != null)
                    {
                        value = prop.GetValue(model, null);
                    }
                }
                catch (Exception ex)
                {
                    //TODO Logging here
                }
                // remove substring with pattern
                // use remove instead of replace, since 
                // you may have several the same string
                // and insert what required
                body = body.Remove(fullMatch.Index, fullMatch.Length)
                    .Insert(fullMatch.Index, value.ToString());
            }
            return body;
        }
    }
