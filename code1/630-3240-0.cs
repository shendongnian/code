    // Clear the response buffer incase there is anything already in it.
    Response.Clear();
    Response.Buffer = true;
    
    // Read the original file from disk
    FileStream myFileStream = new FileStream(sPath, FileMode.Open);
    long FileSize = myFileStream.Length;
    byte[] Buffer = new byte[(int)FileSize];
    myFileStream.Read(Buffer, 0, (int)FileSize);
    myFileStream.Close();
    
    // Tell the browse stuff about the file
    Response.AddHeader("Content-Length", FileSize.ToString());
    Response.AddHeader("Content-Disposition", "inline; filename=" + sFilename.Replace(" ","_"));
    Response.ContentType = getMimeType(sExtention, oConnection);
    
    // Send the data to the browser
    Response.BinaryWrite(Buffer);
    Response.End();
