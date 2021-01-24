    [HttpPost("{coverPagePath}")] 
    public void Post([FromRoute] string coverPagePath, [FromBody] UserCoverpage value)
    {
       var args = new[] { WebUtility.UrlDecode(coverPagePath).Replace("\\", "/") };
       userCoverpageService.Create(value, args);
    }
    ...
    //test:
    var json = item.SerializeToJson(true);
    HttpContent payload = new StringContent(json, Encoding.UTF8, "application/json");
    
    // act
    var response = await httpClient.PostAsync($"/api/UserCoverpage/{coverPagePath}", payload); 
    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
    output.WriteLine(data);
