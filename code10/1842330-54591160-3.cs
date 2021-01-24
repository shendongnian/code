    private static string GetEncodedCredentials(string userid, string password)
    {
        string mergedCredentials = string.Format("{0}:{1}", userid, password);
        byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
        return Convert.ToBase64String(byteCredentials);
    }
