	using (var sftp = new SftpClient("localhost", "a","b"))
	{
		sftp.Connect();
		using (MemoryStream ms = new MemoryStream())
		{
			Bitmap bmp = new Bitmap(10,10);
			bmp.Save(ms,ImageFormat.Bmp);
			ms.Seek(0, SeekOrigin.Begin);
			
			sftp.UploadFile(ms,"File.bmp");
			
		}
	}
