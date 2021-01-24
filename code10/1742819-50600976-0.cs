    using (var randAccessStream = await file.OpenAsync(FileAccessMode.Read, StorageOpenOptions.AllowReadersAndWriters))
            using (var inputStream = randAccessStream.AsStream())
            using (var streamReader = new StreamReader(inputStream))
            {
                var oldsize = randAccessStream.Size;
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (oldsize != randAccessStream.Size)
                    {
                        /*Debug.WriteLine($"old: {oldsize} -> new: {randAccessStream.Size}");
                        Debug.WriteLine($"position: {randAccessStream.Position}");*/
                        oldsize = randAccessStream.Size;
                        await Task.Delay(100);
                    }
                }
                await inputStream.FlushAsync();
                streamReader.Close();
                inputStream.Dispose();
                randAccessStream.Dispose();
            }
