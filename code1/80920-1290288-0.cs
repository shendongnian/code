    string pathToFile = @"G:\My Documents\donkeysex.txt";
    
    StreamReader sr = null;
    
    try
    {
    	sr = new StreamReader(pathToFile);
    	sr.Read();
    	// etc.
    }
    catch (System.IO.FileNotFoundException ex)
    {
    	// Handle exception
    }
    catch (System.IO.DirectoryNotFoundException ex)
    {
    	// Handle exception
    }
    catch (System.IO.IOException ex)
    {
    	// Handle exception
    }
    catch (Exception ex)
    {
    	// Handle exception
    }
    finally
    {
    	if (sr != null)
    		sr.Dispose();
    }
