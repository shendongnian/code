    string _username = string.Empty;
    string _password = string.Empty;
    string _url = "http://example.com";
    string _writeTestFileNameZip = string.Empty;
    using (WebClient _webClient = new WebClient())
    {
        _webClient.Headers[HttpRequestHeader.UserAgent] = "Test";
        _webClient.Headers[HttpRequestHeader.CacheControl] = "no-cache";
        _webClient.Headers[HttpRequestHeader.Authorization] = $"{Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_password}"))}";
        using (Stream _output = await _webClient.OpenWriteTaskAsync(_url))
        using (FileStream _fileStream = new FileStream(@"c:\tmp\install.esd", FileMode.Open, FileAccess.Read))
        {
            byte[] _readByteBuffer = new byte[1024 * 4];
            long _bytesToRead = _fileStream.Length;
            int _bytesRead = 0;
            
            _fileStream.Seek(0, SeekOrigin.Begin);
            while ((_bytesRead = await _fileStream.ReadAsync(_readByteBuffer, 0, _readByteBuffer.Length)) > 0)
            {
                await _output.WriteAsync(_readByteBuffer, 0, _bytesRead);
            }
        }
    }
