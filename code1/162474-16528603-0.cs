    private async void GetAllImages ()
    {
        var downloadTasks = listOfURLs.Where(url =>   !string.IsNullOrEmpty(url)).Select(async url =>
                {
                    var ret = await RetrieveImage(url);
                    return ret;
            }).ToArray();
            var counts = await Task.WhenAll(downloadTasks);
    }
    //From the Collector class
    public async Task<Image> RetrieveImage(string url)
    {
        var lambdaVar = url;  //Required... Bleh
        using (WebClient client = new WebClient())
        {
            //TODO: Replace with live image locations
            var fileName = String.Format("{0}.png", i);
            await client.DownloadFile(lambdaVar, Path.Combine(Application.StartupPath, fileName));
        }
        return Image.FromFile(Path.Combine(Application.StartupPath, fileName));
    }  
