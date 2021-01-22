    byte[] buffer =
         Encoding.UTF8.GetBytes(
             String.Join("&",
                 Array.ConvertAll<KeyValuePair<string, string>, string>(
                     inputs.ToArray(), (item) => item.Key + "=" + HttpUtility.UrlEncode(item.Value))));
    
