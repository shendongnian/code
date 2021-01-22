    private byte [] StreamFile(string filename)
    {
      FileStream fs = new FileStream(filename, FileMode.Open,FileAccess.Read);
      // Create a byte array of file stream length
      byte[] ImageData = new byte[fs.Length];
      //Read  block of bytes from stream into the byte array
      fs.Read(ImageData,0,System.Convert.ToInt32(fs.Length));
      //Close the File Stream
      fs.Close();
      return ImageData;
    }
    // then use the following to add the file to the list
    list.RootFolder.Files.Add(fileName, StreamFile(fileName));
