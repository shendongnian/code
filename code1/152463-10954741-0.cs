    void HeaderNameValueEncode (string headerName, string headerValue, out string encodedHeaderName, out string encodedHeaderValue)
    {
            if (String.IsNullOrEmpty (headerName))
                    encodedHeaderName = headerName;
            else
                    encodedHeaderName = EncodeHeaderString (headerName);
            if (String.IsNullOrEmpty (headerValue))
                    encodedHeaderValue = headerValue;
            else
                    encodedHeaderValue = EncodeHeaderString (headerValue);
    }
    static void StringBuilderAppend (string s, ref StringBuilder sb)
    {
            if (sb == null)
                    sb = new StringBuilder (s);
            else
                    sb.Append (s);
    }
    static string EncodeHeaderString (string input)
    {
            StringBuilder sb = null;
            
            for (int i = 0; i < input.Length; i++) {
                    char ch = input [i];
                    if ((ch < 32 && ch != 9) || ch == 127)
                            StringBuilderAppend (String.Format ("%{0:x2}", (int)ch), ref sb);
            }
            if (sb != null)
                    return sb.ToString ();
            return input;
    }
