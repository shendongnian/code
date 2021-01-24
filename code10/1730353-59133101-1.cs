    using Windows.Storage;
    using Windows.Storage.Pickers;
    .....
    StorageFile file;
    ......
    
    private async void btnFileUpload_Click(object sender, RoutedEventArgs e) // Like Browse button 
    {
    	try
    	{
    		FileOpenPicker openPicker = new FileOpenPicker();
    		openPicker.ViewMode = PickerViewMode.Thumbnail;
    		openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    		openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
    		file = await openPicker.PickSingleFileAsync();
    		if (file != null)
    		{
    			//fetch file details
    		}
    	}
    	catch (Exception ex)
    	{
    
    	}
    }
    		
    //When upload file
    var http = new HttpClient();
    var formContent = new HttpMultipartFormDataContent();
    var fileContent = new HttpStreamContent(await file.OpenReadAsync());
    formContent.Add(fileContent, "allfiles", file.Name);
    var response = await http.PostAsync(new Uri("Give API Path" + "UploadImages", formContent);
    string filepath = Convert.ToString(response.Content); //Give path in which file is uploaded
