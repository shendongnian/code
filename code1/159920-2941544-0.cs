    public void EncodeWithString() {
        System.IO.FileStream inFile;     
        byte[] binaryData;
    
        try {
            inFile = new System.IO.FileStream(inputFileName,
                                              System.IO.FileMode.Open,
                                              System.IO.FileAccess.Read);
            binaryData = new Byte[inFile.Length];
            long bytesRead = inFile.Read(binaryData, 0,
                                        (int)inFile.Length);
            inFile.Close();
        }
        catch (System.Exception exp) {
            // Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message);
            return;
        }
    
        // Convert the binary input into Base64 UUEncoded output.
        string base64String;
        try {
             base64String = 
                System.Convert.ToBase64String(binaryData, 
                                              0,
                                              binaryData.Length);
        }
        catch (System.ArgumentNullException) {
            System.Console.WriteLine("Binary data array is null.");
            return;
        }
    
        // Write the UUEncoded version to the XML file.
        System.IO.StreamWriter outFile; 
        try {
            outFile = new System.IO.StreamWriter(outputFileName,
                                        false,
                                        System.Text.Encoding.ASCII);             
            outFile.Write("<BinaryFileString fileType='pdf'>");
            outFile.Write(base64String);
            outFile.Write("</BinaryFileString>");
            outFile.Close();
        }
        catch (System.Exception exp) {
            // Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message);
        }
    }
