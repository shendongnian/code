    using (Stream stream = GetStreamFromSomewhere())
    {
      using (
        XmlDictionaryReader mtomReader = XmlDictionaryReader.CreateMtomReader(
            stream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max))
     {
        string elementString = mtomReader.ReadElementString();
        byte[] buffer = new byte[1024];
        using (
            Stream elementFileStream =
                new FileStream(tempFileLocation, FileMode.Create))
        {
            while(mtomReader.XmlReader.ReadElementContentAsBase64(buffer,0,buffer.Length)
            {
              elementFileStream.Write(buffer, 0, buffer.Length);
            }
        }
        /// ...
        mtomReader.Close();
     }
    }
