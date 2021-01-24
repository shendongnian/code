    HttpClient client = Api.GetHttpClient();
    var postData = new PostData {ids = new[] {10545801, 10731939}};
    var json = JsonConvert.SerializeObject(postData);
    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync($"{client.BaseAddress}/classifications/{classification.id}/accounts/add", httpContent);
