    private int _bufferSize = 16384;
    private void ReadFile(string filename)
    {
        StringBuilder stringBuilder = new StringBuilder();
        FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader(fileStream))
        {
            char[] fileContents = new char[_bufferSize];
            int charsRead = streamReader.Read(fileContents, 0, _bufferSize);
            // Can't do much with 0 bytes
            if (charsRead == 0)
                throw new Exception("File is 0 bytes");
            while (charsRead > 0)
            {
                stringBuilder.Append(fileContents);
                charsRead = streamReader.Read(fileContents, 0, _bufferSize);
            }
        }
    }
