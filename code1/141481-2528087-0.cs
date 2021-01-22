    public void ReadObjectAsync<T>(string filename, Action<T> callback)
    {
        ThreadPool.QueueUserWorkItem(s =>
        {
            T result = ReadObject<T>(fileName);
            callback(result);
        });
    }
