    var  subscriptionId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
    var  resourceGroupName = "stackoverflow000000-AMS-ResourceGroup";
    var  serviceName = "stackoverflow000000-AMS-Name";
    var baseUrl = "https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}"
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Add("Authorization", _azureApiManagementFunctions.CreateSharedAccessToken());
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
        var filter = $"contains(properties/ownerId, 'users/{user.Id}')";
    
        response = await client.GetAsync($"/subscriptions?api-version={apiVersion}&$filter={filter}");
        var contents = await response.Content.ReadAsStringAsync();
        var contentsJson = JsonConvert.DeserializeObject<ApimSubscription>(contents);
    };
 
