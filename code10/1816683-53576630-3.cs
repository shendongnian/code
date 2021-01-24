    public async Task LaunchRelease(string tfsServerIncludingCollection, string personalAccessToken, string projectName, int releaseId, int environmentId) {
        //Create the URI with the environment to deploy to:
        var releaseUrl = $"{tfsServerIncludingCollection}/{projectName}/_apis/release/releases/{releaseId}/environments/{environmentId}?api-version=3.0-preview.2";
        //Create the patch Document
        var patchDocument = new {
            status = "inProgress", //Reference https://docs.microsoft.com/en-us/rest/api/azure/devops/release/releases/update%20release%20environment?view=azure-devops-rest-4.1#environmentstatus
        };
        var json = JsonConvert.SerializeObject(patchDocument);
        var patchContent = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
        
        using (var client = new HttpClient()) {
            var base64Token = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalAccessToken}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Token);
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, releaseUrl) { Content = patchContent };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode) {
                var result = await response.Content.ReadAsStringAsync();
                //...
            }else {
                var error = await response.Content.ReadAsStringAsync();
                //...
            }
        }
    }
    
