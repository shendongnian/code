    public static T PutAsync<T>(string resourceUri, object request)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(resourceUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var responseMessage = client.PutAsJsonAsync(resourceUri, request).Result;
                
                responseMessage.EnsureSuccessStatusCode();
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
    }
