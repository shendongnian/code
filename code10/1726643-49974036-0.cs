     public FileResult DownloadMultipleFiles(List<byte[]> byteArrayList)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
				{
					foreach(var file in byteArrayList)
					{
						var entry = archive.CreateEntry(file.fileName +".pdf", CompressionLevel.Fastest);
						using (var zipStream = entry.Open()) 
						{
							zipStream.Write(file, 0, file.Length);
						}
					}
				}
				
				return File(ms.ToArray(), "application/zip", "Archive.zip");
			}
		}
   
