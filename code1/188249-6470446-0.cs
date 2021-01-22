    private static int GetStatusCode(WebClient client, out string statusDescription)
    {
        FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);
        if (responseField != null)
        {
            HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;
            if (response != null)
            {
                statusDescription = response.StatusDescription;
                return (int)response.StatusCode;
            }
        }
        statusDescription = null;
        return 0;
    }
