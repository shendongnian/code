    void Main()
    {
    	//Setup streams for testing
    	using(var inputStream = new MemoryStream())
    	using(var outputStream = new MemoryStream())
    	using (var inputWriter = new StreamWriter(inputStream))
    	using (var outputReader = new StreamReader(outputStream))
    	{
    		//Write test string and rewind stream
    		inputWriter.Write("abcdefghijklmnop");
    		inputWriter.Flush();
    		inputStream.Seek(0, SeekOrigin.Begin);
    
    		var inputBuffer = new byte[5];
    		var outputBuffer = new byte[5];
    		int inputLength;
    		while ((inputLength = inputStream.Read(inputBuffer, 0, inputBuffer.Length)) > 0)
    		{
    			for (var i = 0; i < inputLength; i++)
    			{
    				//transform each character
    				outputBuffer[i] = ++inputBuffer[i];
    			}
    
    			//Write to output
    			outputStream.Write(outputBuffer, 0, inputLength);
    		}
    
    		//Read for testing
    		outputStream.Seek(0, SeekOrigin.Begin);
    		var output = outputReader.ReadToEnd();
    		Console.WriteLine(output);
    		
    		//Outputs: "bcdefghijklmnopq"
    	}
    
    }
