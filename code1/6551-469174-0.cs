    using (BinaryWriter bw = new BinaryWriter (File.Open (strFile, FileMode.Open)))
    {
    	string strNewData = "this is some new data";
    	byte[] byteNewData = new byte[strNewData.Length];
    
        // copy contents of string to byte array
    	for (var i = 0; i < strNewData.Length; i++)
    	{
    		byteNewData[i] = Convert.ToByte (strNewData[i]);
    	}
    
        // write new data to file
    	bw.Write (byteNewData, 15 /* position to start writing */, byteNewData.Length);
    }
