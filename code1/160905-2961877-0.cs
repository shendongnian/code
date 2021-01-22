    public DateTime? GetModifiedTime(string fileName)
    {
        DateTime? retVal = null;
        try
        {
           FileInfo fi = new FileInfo(fileName);
           retVal = fi.LastWriteTime; // .LastWriteTimeUtc if you want it in UTC
        }
        catch(IOException ioe)
        {
           // Do something with the IO Exception, could be a permissions thing,
           // could be file not found, you should split it into a couple 
           // different catch() {} blocks to handle them seperately.
        }
        return retVal;
    }
