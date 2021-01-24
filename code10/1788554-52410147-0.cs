    imgUrl = "http://example.com/myimage.jpg";
    imgName = Path.GetFileName(imgUrl);
 
    byte[] data;
	using (WebClient client = new WebClient())
		data = client.DownloadData(imgUrl);
	if (data != null)
	{
		using (MemoryStream ioStream = new MemoryStream(data))
		{
			var path = System.IO.Path.Combine("~/Content/Images/" + imgName);
			var fromStream = Image.FromStream(ioStream);
			Image image = new Bitmap(fromStream);
			fromStream.Dispose();
			using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
			{
				image.Save(ioStream, System.Drawing.Imaging.ImageFormat.Jpeg);
				byte[] bytes = ioStream.ToArray();
				fs.Write(bytes, 0, bytes.Length);
			}
			
		}
	}
