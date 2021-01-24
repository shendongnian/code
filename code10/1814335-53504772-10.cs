    //...
    // Create the byte array[]
    UTF8Encoding encoding = new UTF8Encoding();
    byte[] mailContent = encoding.GetBytes("TEST");
    // Create the MailBuffer object that have to be passed to the API into the request body:
    MailBuffer content = new MailBuffer();
    content.Nome = "blablabla";
    content.Buffer = mailContent;
    
    //...
    Stream newStream = spRequest.GetRequestStream();
    newStream.Write(mailContent, 0, mailContent.Length); //<---HERE ONLY SENDING encoding.GetBytes("TEST")
    
