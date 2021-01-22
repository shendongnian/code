    private void ValidateString(string s, string valueName, string collectionName)
    {
        int matchIndex = 0;
        if (CrossSiteScriptingValidation.IsDangerousString(s, out matchIndex))
        {
            string str = valueName + "=\"";
            int startIndex = matchIndex - 10;
            if (startIndex <= 0)
            {
                startIndex = 0;
            }
            else
            {
                str = str + "...";
            }
            int length = matchIndex + 20;
            if (length >= s.Length)
            {
                length = s.Length;
                str = str + s.Substring(startIndex, length - startIndex) + "\"";
            }
            else
            {
                str = str + s.Substring(startIndex, length - startIndex) + "...\"";
            }
            throw new HttpRequestValidationException(HttpRuntime.FormatResourceString("Dangerous_input_detected", collectionName, str));
        }
    }
