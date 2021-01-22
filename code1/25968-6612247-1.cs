    //If you don't have .Net 4.0  :)
    public void SaveStreamToFile(Stream stream, string filename)
    {  
       using(Stream destination = File.Create(filename))
          Write(stream, destination);
    }
    //Typically I implement this Write method as a Stream extension method. 
    //The framework handles buffering.
    
    public void Write(Stream from, Stream to)
    {
       for(int a = from.ReadByte(); a != -1; a = from.ReadByte())
          to.WriteByte( (byte) a );
    }
    /*
    Note, StreamReader is an IEnumerable<Char> while Stream is an IEnumbable<byte>.
    The distinction is significant such as in multiple byte character encodings 
    like Unicode used in .Net where Char is one or more bytes (byte[n]). Also, the
    resulting translation from IEnumerable<byte> to IEnumerable<Char> can loose bytes
    or insert them (for example, "\n" vs. "\r\n") depending on the StreamReader instance
    CurrentEncoding.
    */
