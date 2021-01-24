    public async void Upload_FileAsync(string WebServiceURL, string FilePathToUpload)
    {
    
        //prepare HttpStreamContent
        IStorageFile storageFile = await StorageFile.GetFileFromPathAsync(FilePathToUpload);
    
        //Here is the code we changed
        IRandomAccessStream stream=await storageFile.OpenAsync(FileAccessMode.Read);
        Windows.Web.Http.HttpStreamContent streamContent = new Windows.Web.Http.HttpStreamContent(stream);
    
        //send request
        var myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
        myFilter.AllowUI = false;
        var client = new Windows.Web.Http.HttpClient(myFilter);
        Windows.Web.Http.HttpResponseMessage result = await client.PostAsync(new Uri(WebServiceURL), streamContent);
        string stringReadResult = await result.Content.ReadAsStringAsync();
    }
