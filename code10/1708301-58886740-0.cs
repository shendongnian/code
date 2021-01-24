	if (file.Length > 0)
	{
	    using (BinaryReader br = new BinaryReader(file.InputStream))
	    {
	        /* ... use file.Length or file.ContentLength */
	        byte[] bytes = br.ReadBytes(file.Length);
	        /* ... File Processing (bytes) */	        
	    }
	}
. 
