    public static string Translate(string pattern, object context)
    {
        return Regex.Replace(pattern, @"\{!(\w+)!}", match => {
            string tag = match.Groups[1].Value;
            if (context != null)
            {
                PropertyInfo prop = context.GetType().GetProperty(tag);
                if (prop != null)
                {
                    object value = prop.GetValue(context);
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            return "";
        });
    }
