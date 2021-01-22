    try
    {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://somewhere/picture.jpg");
    	request.Credentials = System.Net.CredentialCache.DefaultCredentials;
    	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    	myImg.ImageUrl = "http://somewhere/picture.jpg";
    }
    catch (Exception ex)
    {
    	// image doesn't exist, set to default picture
    	myImg.ImageUrl = "http://somewhere/default.jpg";
    }
