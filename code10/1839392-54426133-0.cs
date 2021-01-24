    ApplicationPkcs7Mime pkcs7;
    
    using (var stream = new MemoryStream ()) {
        byte[] buffer;
    
        // write the Content-Type header
        buffer = Encoding.ASCII.GetBytes ("Content-Type: application/pkcs7-mime; name=smime.p7m\r\n");
        stream.Write (buffer, 0, buffer.Length);
    
        // write the Content-Type header
        buffer = Encoding.ASCII.GetBytes ("Content-Type: application/pkcs7-mime; name=smime.p7m\r\n");
        stream.Write (buffer, 0, buffer.Length);
    
        // write the header termination sequence
        buffer = Encoding.ASCII.GetBytes ("\r\n");
        stream.Write (buffer, 0, buffer.Length);
    
        // write the base64 encoded content
        buffer = Encoding.ASCII.GetBytes (base64);
        stream.Write (buffer, 0, buffer.Length);
    
        // rewind the stream
        stream.Position = 0;
    
        pkcs7 = (ApplicationPkcs7Mime) MimeEntity.Load (stream);
    }
