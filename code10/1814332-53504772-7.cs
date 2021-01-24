    //...
    // Create the byte array[]
    UTF8Encoding encoding = new UTF8Encoding();
    byte[] mailContent = encoding.GetBytes("TEST");
    
    //...
    Stream newStream = spRequest.GetRequestStream();
    newStream.Write(mailContent, 0, mailContent.Length); //<---HERE ONLY SENDING encoding.GetBytes("TEST")
    
