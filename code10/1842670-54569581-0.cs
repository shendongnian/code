	Observable
		.FromAsync(() => downloader.DownloadAsZipArchive(downloadUrl))
		.SelectMany(z =>
			Observable
				.Using(() => z, zip => Observable.Start(() =>
				{
					var temp = FileUtils.GetTempDirectoryName();
					zip.ExtractToDirectory(temp);   // BLOCKING CALL
			
					if (Directory.Exists(folderPath))
					{
						Directory.Delete(folderPath, true);
					}
			
					var firstChild = Path.Combine(temp, folderName);
					Directory.Move(firstChild, folderPath);
					Directory.Delete(temp);				
				})))
		.Subscribe();
