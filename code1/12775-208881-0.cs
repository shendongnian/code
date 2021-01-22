    public class MyFooBarClass
    {
       private static ReaderWriterLock readerWriterLock = new ReaderWriterLock();
       private static MemoryStream fileMemoryStream;
    
       // other instance members here
    
       public void MyFooBarClass()
       {
    	 if(fileMemoryStream != null)
    	 {
    		// probably expensive file read here
    	 }
    	  
    	 // initialize instance members here
       }
    
       public byte[] ReadBytes()
       {
    	try
    	{
    		try
    		 {
    			readerWriterLock.AcquireReaderLock(1000);
    			//... read bytes here
    			return bytesRead;
    		 }
    		 finally
    		 {
    			readerWriterLock.ReleaseReaderLock();
    		 }
    	 }
    	 catch(System.ApplicationException ex)
    	 {
    		System.Diagnostics.Debug.WriteLine(ex.Message);
    	 }
       }
    
       public void WriteBytes(bytes[] bytesToWrite)
       {
    	try
    	{
    		try
    		 {
    			readerWriterLock.AcquireWriterLock(1000);
    			//... write bytes here
    		 }
    		 finally
    		 {
    			readerWriterLock.ReleaseWriterLock();
    		 }
    	 }
    	 catch(System.ApplicationException ex)
    	 {
    		System.Diagnostics.Debug.WriteLine(ex.Message);
    	 }
       }
    }
