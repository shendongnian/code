        /// <summary>
        /// This method is used to create a StorageFile and save the stream into it, then return this StorageFile
        /// </summary>
        /// <returns></returns>
        private async Task<StorageFile> GetFile()
        {
            StorageFile storageFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("Temp.jpg",CreationCollisionOption.ReplaceExisting);
            using (var Srcstream = ClassLibrary1.Class1.GetImage())
            {
                using (var targetStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (var reader = new DataReader(Srcstream.AsInputStream()))
                    {
                        var outpustream = targetStream.GetOutputStreamAt(0);
                        await reader.LoadAsync((uint)Srcstream.Length);
                        while (reader.UnconsumedBufferLength >0)
                        {
                            uint datatoend = reader.UnconsumedBufferLength > 128 ? 128 : reader.UnconsumedBufferLength;
                            IBuffer buffer = reader.ReadBuffer(datatoend);
                            await outpustream.WriteAsync(buffer);
                        }
                        await outpustream.FlushAsync();
                    }
                }
            }
            return storageFile;
        }
