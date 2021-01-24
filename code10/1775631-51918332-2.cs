    var request = WebRequest.CreateHttp("http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0");//"http://spreadsheetpage.com/downloads/xl/king-james-bible.xlsm");
			var response = request.GetResponse();
			string disposition = response.Headers["Content-Disposition"];
			string filename = disposition.Substring(disposition.IndexOf("filename=") + 9).Replace("\"", "");
			using (var fs = new FileStream(filename.Replace("/", "-"), FileMode.Create, FileAccess.Write, FileShare.None))
			{
				using (var stream = response.GetResponseStream())
				{
					using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress))
					{
						byte[] tempBytes = new byte[4096];
						int i;
						while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
						{
							fs.Write(tempBytes, 0, i);
						}
					}
				}
			}
