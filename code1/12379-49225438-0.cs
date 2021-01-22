    public static async Task<byte[]> GetBytesAsync(string url) {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add(ApiConfig.OcpApimSubscriptionKeyHeader, ApiConfig.AzureSubscriptionKey);
        using (var response = await request.GetResponseAsync())
        using (var content = new MemoryStream())
        using (var responseStream = response.GetResponseStream()) {
            await responseStream.CopyToAsync(content);
            return content.ToArray();
        }
    }
    
    public static async Task<string> GetStringAsync(string url) {
        var bytes = await GetBytesAsync(url);
        return Bytes2String(bytes);
    }
    
    public static string Bytes2String(byte[] bytes) {
        return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
    }
