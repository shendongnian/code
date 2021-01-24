	public async void SetProfilePicture()
	{
		HttpClient http = new HttpClient();
		string url = string.Format("YOUR URL");
		HttpResponseMessage response = await http.GetAsync(url);
		var result = await response.Content.ReadAsStringAsync();
		var deserialized = JsonConvert.DeserializeObject<List<Customer>>(result);
		// Bitmap samples are here in a byte array
		byte[] samples = deserialized[0].ProfilePicture;
		
		//Here you set the width and height
		WriteableBitmap bitmap = new WriteableBitmap(128, 128);
		
		System.IO.Stream bitmapStream = null;
		bitmapStream = bitmap.PixelBuffer.AsStream();
		bitmapStream.Position = 0;
		
		await bitmapStream.WriteAsync(samples, 0, 4 * 128 * 128);
		
		bitmapStream.Flush();
		imgData.Source = bitmap;
	}
