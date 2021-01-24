    public static async Task PutFileAsync()
    {
    	List<SharePointListItems.Lookup> Lookups = new List<SharePointListItems.Lookup>();
    	string genName = App.Generator;
    	genName = genName.Replace(" ", "-");
    	StorageLibrary videoLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
    	string readFolder = videoLibrary.SaveFolder.Path;
    	StorageFolder videoFolder = await StorageFolder.GetFolderFromPathAsync(readFolder);
    	string readFileName = App.Date + "-" + App.StartTime + "-" + App.IBX + "-" + genName + ".xlsx";
    	StorageFile readFile = await videoFolder.GetFileAsync(readFileName);
    	byte[] result;
    	using (Stream stream = await readFile.OpenStreamForReadAsync())
    	{
    		using (var memoryStream = new MemoryStream())
    		{
    			stream.CopyTo(memoryStream);
    			result = memoryStream.ToArray();
    		}
    	}
    	var (authResult, message) = await Authentication.AquireTokenAsync();
    	var httpClient = new HttpClient();
    	HttpResponseMessage response;
    	string posturl = MainPage.spfileurl + readFile.Name + ":/content";
    	var request = new HttpRequestMessage(HttpMethod.Put, posturl);
    	request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
    	request.Content = new ByteArrayContent(result);
    	response = await httpClient.SendAsync(request);
    	var responseString = await response.Content.ReadAsStringAsync();
    	JObject json = JObject.Parse(responseString);
    	var result3 = JsonConvert.DeserializeObject<SharePointDocumentNew.RootObject>(responseString);
    	eTag = result3.eTag.ToString();
    	eTag = eTag.Replace("\"{", "");
    	string replacement = "";
    	string endPattern = "}.*";
    	Regex rgxend = new Regex(endPattern);
    	eTag = rgxend.Replace(eTag, replacement);
    	eTag = Regex.Replace(eTag, @"[A-Z]+?", m => m.ToString().ToLower());
    
    	await Task.Run(() =>
    	{
    		File.Delete(readFile.Path);
    		return TaskStatus.RanToCompletion;
    	});
    }
    
    public static async Task GetFileDataAsync()
    {
    	List<SharePointDocumentItems.Value> Value2 = new List<SharePointDocumentItems.Value>();
    	var (authResult2, message2) = await Authentication.AquireTokenAsync();
    	var httpClient2 = new HttpClient();
    	HttpResponseMessage response2;
    	string geturl = "https://graph.microsoft.com/v1.0/sites/mycoinc.sharepoint.com,495435b4-60c3-49b7-8f6e-1d262a120ae5,0fad9f67-35a8-4c0b-892e-113084058c0a/lists/edd49389-7edb-41db-80bd-c8493234eafa/items";
    	var request2 = new HttpRequestMessage(HttpMethod.Get, geturl);
    	request2.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult2.AccessToken);
    	response2 = await httpClient2.SendAsync(request2);
    	var responseString2 = await response2.Content.ReadAsStringAsync();
    	JObject json2 = JObject.Parse(responseString2);
    	var result2 = JsonConvert.DeserializeObject<SharePointDocumentItems.RootObject>(responseString2);
    	foreach (var d in result2.value)
    	{
    		string ETAG = d.ETag;
    		string startPattern = "^\\\"";
    		string replacement = "";
    		string endPattern = ",.*";
    		Regex rgxstart = new Regex(startPattern);
    		ETAG = rgxstart.Replace(ETAG, replacement);
    		Regex rgxend = new Regex(endPattern);
    		ETAG = rgxend.Replace(ETAG, replacement);
    		if (ETAG == eTag)
    		{
    			fileID = d.Id;
    		}
    	}
    }
