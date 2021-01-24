    private static HttpClient client = new HttpClient();
    private async Task CurlFileContents(Uri uri, string contents)
    {
        var content = new StringContent(contents, Encoding.Default, "text/plain");
        var repsonse = await client.PutAsync(uri, content);
        var responseContent = await repsonse.Content.ReadAsStringAsync();
        //operate on response
    }
