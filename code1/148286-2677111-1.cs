    UrlEncodedData = HttpUtility.UrlEncode(base64Salt + base64IV, ASCII_ENCODING);
    ...
    string s = HttpUtility.UrlDecode(UrlEncodedData, ASCII_ENCODING);
    base64DecodedBytes = Convert.FromBase64String(s);
You are catenating two Base64-encoded strings then trying to Base64-decode the combination. This will only work if your base64Salt is a multiple of six bits, and in your case it is not. Data not such a multiple gets Base64-encoded with a trailing '=' character, catenating it puts the '=' in the middle of the string, which is not a valid Base64 string.
