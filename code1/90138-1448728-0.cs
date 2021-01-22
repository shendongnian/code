    while(bytesWritten < totalBytes)
    {
       bytesWritten += br.Write(buffer);
       myFileInfo.LastWriteTime = DateTime.Now;
    }
