    using System.Security.Authentication;
    [HttpGet]
    public async Task<IActionResult> Department() {
        try {
	        var myObject = await GetSafeData<Department[]>("api/Department");
	        return view(myObj);
        } catch(AuthenticationException ex) {
	        return RedirectToAction("AccessDenied", "Authorization");
        }
    }
    internal T GetSafeData<T>(string url) {
        using (var client = await _apiHttpClient.GetHttpClientAsync()) {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                Throw New AuthenticationException("");
            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }
    }
