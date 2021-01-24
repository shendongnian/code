    public void ProcessLargeFile(string fileName)
    {
        int bufferSize = 100 * 1024 * 1024; // 100MB
        byte[] buffer = new byte[bufferSize];
        int bytesRead = 0;
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            while ((bytesRead = fs.Read(buffer, 0, bufferSize)) > 0)
            {
                if (bytesRead < bufferSize)
                {
                    // please note array contains only 'bytesRead' bytes from 'bufferSize'
                }
                // here 'buffer' you get current portion on file 
                // process this
            }
        }
    }
