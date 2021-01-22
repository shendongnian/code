    public static class Helper{
    
    public static IEnumerable<KeyValuePair<string, string>> ToPairs(this NameValueCollection Form)
            {
                return Form.AllKeys.Cast<string>()
                    .Select(key => new KeyValuePair<string, string>(key, Form[key]));
            }
    }
