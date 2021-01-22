				public static byte[] ObjectToCompressedByteArray(object obj)
						{
							try
							{
								using (var memoryStream = new System.IO.MemoryStream())
								{
									using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
									{
										var binaryFormatter = new BinaryFormatter();
										binaryFormatter.Serialize(gZipStream, obj);
									}
									return memoryStream.ToArray();
								}
							}
							catch (Exception ex)
							{
								LoggerWrapper.CMLogger.LogMessage(
									$"EXCEPTION: BSExportImportHelper.ObjectToByteArray - : {ex.Message}", LoggerWrapper.CMLogger.CMLogLevel.Error);
								throw;
							}
						}
