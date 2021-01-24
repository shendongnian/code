    public static async Task<List<DataRecord>> GetDataAsync(StorageFile file)
    {
        List<DataRecord> recordsList = new List<DataRecord>();
        using (Stream stream = await file.OpenStreamForReadAsync().ConfigureAwait(false))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync().ConfigureAwait(false);
                    // Does its parsing here, and constructs a single DataRecord …
                    recordsList.Add(dataRecord);
                    // Raises an event.
                    MyStorageWrapper.RaiseMyEvent(recordsList.Count);
                }
            }
        }
        return recordsList;
    }
