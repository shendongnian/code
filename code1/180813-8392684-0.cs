    public IDictionary<string, object> DecodePayload(string payload)
    {
        string base64 = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=')
            .Replace('-', '+').Replace('_', '/');
        string json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        return (IDictionary<string, object>)new JavaScriptSerializer().DeserializeObject(json);
    }
