    HttpClient httpClient = new HttpClient();
    MultipartFormDataContent mt = new MultipartFormDataContent();
    AttachedImage.GetStream().Position = 0;
    StreamContent imagePart = new StreamContent(AttachedImage.GetStream());
    imagePart.Headers.Add("Content-Type", ImageType);
    mt.Add(imagePart, String.Format("file"), String.Format("bk.jpeg"));
    
    requestMessage.Content = mt;
    
    
    var response = await httpClient.PostAsync("Your URL", mt);
    if (response.IsSuccessStatusCode)
    {
        var responseString = await response.Content.ReadAsStringAsync();
        var objRootObjectuploadImage = JsonConvert.DeserializeObject<RootObjectuploadImage>(responseString);
        if (objRootObjectuploadImage != null)
        {
            
        }
        else
        {
          
        }
    }
    else
    {
        Loading(ActIndicator, false);
        await DisplayAlert(res.LAlert, "webserver not responding.", res.LOk);
    }
