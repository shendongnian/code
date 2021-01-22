    public void MyDownloadFile(Uri url, string outputFilePath)
    {
        const int BUFFER_SIZE = 16 * 1024;
        using (var outputFileStream = File.Create(outputFilePath, BUFFER_SIZE))
        {
            var req = WebRequest.Create(url);
            using (var response = req.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var buffer = new byte[BUFFER_SIZE];
                    int bytesRead;
                    do
                    {
                        bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
                        outputFileStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                }
            }
        }
    }
