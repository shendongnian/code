    using System.Net.Http;
        static async Task<string> PostURI(Uri u, HttpContent c)
        {
        var response = string.Empty;
        using (var client = new HttpClient())
        {
        HttpResponseMessage result = await client.PostAsync(u, c);
        if (result.IsSuccessStatusCode)
        {
        response = result.StatusCode.ToString();
        }
        }
        return response;
        }
