    var page = await graphClient.Me.Drive.Items[itemId].Thumbnails.Request().GetAsync();
    var thumbnailSet = page.FirstOrDefault();
    var thumbnail = thumbnailSet?.Medium;
    using (var client = new System.Net.WebClient())
    {
        var content = client.DownloadData(thumbnail.Url);  //download it as a byte array
     
        System.IO.File.WriteAllBytes(targetFileName, content); //save into file
    }
