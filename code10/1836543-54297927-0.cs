	cacheName = Path.Combine(CacheDir.AbsolutePath, Path.GetTempFileName());
	using (var cacheFile = new Java.IO.File(cacheName)) 
	using (var photoURI = FileProvider.GetUriForFile(this, PackageName + ".fileprovider", cacheFile))
	using (var intent = new Intent(MediaStore.ActionImageCapture))
	{
		intent.PutExtra(MediaStore.ExtraOutput, photoURI);
		StartActivityForResult(intent, 88);
	}
