    /// <summary>
    /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
    /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
    /// </summary>
    /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
    /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
    /// <param name="method">The HTTP method.</param>
    /// <param name="requestUri">The URI that the request will be sent to.</param>
    /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
    /// <returns>The response parsed as an object of the generic type.</returns>
    public static async Task<T> SendJsonAsync<T>(this HttpClient httpClient, HttpMethod method, string requestUri, object content)
    {
        var requestJson = JsonUtil.Serialize(content);
        var response = await httpClient.SendAsync(new HttpRequestMessage(method, requestUri)
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        });
        if (typeof(T) == typeof(IgnoreResponse))
        {
            return default;
        }
        else
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonUtil.Deserialize<T>(responseJson);
        }
    }
