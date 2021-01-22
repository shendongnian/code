    public static async Task IsFileReady(string filename)
		{
			await Task.Run(() =>
			{
				if (!File.Exists(path))
				{
					throw new IOException("File does not exist!");
				}
				var isReady = false;
				while (!isReady)
				{
					// If the file can be opened for exclusive access it means that the file
					// is no longer locked by another process.
					try
					{
						using (FileStream inputStream =
							File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
							isReady = inputStream.Length > 0;
					}
					catch (Exception e)
					{
						// Check if the exception is related to an IO error.
						if (e.GetType() == typeof(IOException))
						{
							isReady = false;
						}
						else
						{
							// Rethrow the exception as it's not an exclusively-opened-exception.
							throw;
						}
					}
				}
			});
		}
    
