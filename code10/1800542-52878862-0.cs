    private async void btnSearch_Click(object sender, EventArgs e)
    {
        var newsApiClient = new NewsApiClient("keyredacted");
        var articleResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
        ...
