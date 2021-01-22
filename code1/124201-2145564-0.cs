    byte[] buffer = 
    Encoding.UTF8.GetBytes(
        String.Join("&", 
            Array.ConvertAll<KeyValuePair<string, string>, string>(
                inputs.ToArray(),
                delegate(KeyValuePair<string, string> item)
                {
                    return item.Key + "=" + System.Web.HttpUtility.UrlEncode(item.Value);
                })));
