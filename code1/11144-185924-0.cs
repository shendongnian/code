    private void decompressFile(string inFile, string outFile)
    {
    	System.IO.FileStream outFileStream = new System.IO.FileStream(outFile, System.IO.FileMode.Create);
    	zlib.ZOutputStream outZStream = new zlib.ZOutputStream(outFileStream);
    	System.IO.FileStream inFileStream = new System.IO.FileStream(inFile, System.IO.FileMode.Open);			
    	try
    	{
    		CopyStream(inFileStream, outZStream);
    	}
    	finally
    	{
    		outZStream.Close();
    		outFileStream.Close();
    		inFileStream.Close();
    	}
    }
