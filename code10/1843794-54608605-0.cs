class WebApiResponse
{
    public string Message { get; set; }
    public Dictionary<string, IList<string>> ModelState { get; set; }
}
Then use the `Newtonsoft.Json` library to deserialize the json response as an instance of the `WebApiResponse` class:
var jsonFromWebApiResponse = @"{""$id"":""1"",""Message"":""The request is invalid."",""ModelState"":{""$id"":""2"","""":{""$id"":""3"",""$values"":[""Name username@gmail.com is already taken.""]}}}";
var webApiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WebApiResponse>(jsonFromWebApiResponse);
foreach (var modelState in webApiResponse.ModelState)
{
    foreach (var innerMessage in modelState.Value)
    {
        // Do something with the messages inside ModelState...
    }
}
