	using (var matFromPng = Imgcodecs.Imread(cachedFileName, Imgcodecs.ImreadColor))
	using (var vect = new MatOfByte())
	{
		if (Imgcodecs.Imencode(".jpg", matFromPng, vect))
		{
			var stream = new MemoryStream(vect.ToArray());
			// Do something with your stream...
			cachedFileName = Path.Combine(CacheDir.AbsolutePath, "her.jpg");
			using (var cacheFilestreamToJpeg = new FileStream(cachedFileName, FileMode.Create, FileAccess.Write))
			{
				stream.CopyTo(cacheFilestreamToJpeg);
			}
			stream.Dispose();
		}
	}
