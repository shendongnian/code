    public static async void ReadAllBytes(string filePath, Action<byte[]> successCallback)
    {
        byte[] result;
        using (FileStream stream = File.Open(filePath, FileMode.Open))
        {
            result = new byte[stream.Length];
            await stream.ReadAsync(result, 0, (int)stream.Length);
        }
        // Now pass the byte[] to the callback
        successCallback.Invoke();
    }
