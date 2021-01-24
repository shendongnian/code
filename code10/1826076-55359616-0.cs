    public async Task SendAsync(float volume, string path, AudioOutStream stream)
    {
        _currentProcess = CreateStream(path);
        while (true)
        {
            if (_currentProcess.HasExited)
            { break; }
            int blockSize = 2880;
            byte[] buffer = new byte[blockSize];
            int byteCount;
            byteCount = await _currentProcess.StandardOutput.BaseStream.ReadAsync(buffer, 0, blockSize);
            if (byteCount == 0)
            { break; }
            await stream.WriteAsync(buffer, 0, byteCount);
         }
        await stream.FlushAsync();
    }
