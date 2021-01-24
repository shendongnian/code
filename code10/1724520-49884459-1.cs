	public void UnZipAssets(string assetName, string destPath)
	{
		byte[] buffer = new byte[1024];
		int byteCount;
		var destPathDir = new Java.IO.File(destPath);
		destPathDir.Mkdirs();
		using (var assetStream = Assets.Open(assetName, Android.Content.Res.Access.Streaming))
		using (var zipStream = new ZipInputStream(assetStream))
		{
			ZipEntry zipEntry;
			while ((zipEntry = zipStream.NextEntry) != null)
			{
				if (zipEntry.IsDirectory)
				{
					var zipDir = new Java.IO.File(Path.Combine(destPath, zipEntry.Name));
					zipDir.Mkdirs();
					continue;					                              
				}
				// Note: This is deleting existing entries(!!!) for debug purposes only...
                #if DEBUG
                if (File.Exists(Path.Combine(destPath, zipEntry.Name)))
					File.Delete(Path.Combine(destPath, zipEntry.Name));
                #endif
				using (var fileStream = new FileStream(Path.Combine(destPath, zipEntry.Name), FileMode.CreateNew))
				{
					while ((byteCount = zipStream.Read(buffer)) != -1)
					{
						fileStream.Write(buffer, 0, byteCount);
					}
				}
				Log.Debug("UnZipAssets", zipEntry.Name);
				zipEntry.Dispose();
			}
		}
	}
