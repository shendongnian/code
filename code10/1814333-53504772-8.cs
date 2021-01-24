    //...
    UTF8Encoding encoding = new UTF8Encoding();
    // Create the MailBuffer object that have to be passed to the API into the request body:
    var content = new MailBuffer() {
        Nome = "blablabla",
        Buffer = encoding.GetBytes("TEST")
    };
    //convert model to JSON using Json.Net
    var jsonPayload = JsonConvert.SerializeObject(content);
    byte[] mailContent = encoding.GetBytes(jsonPayload); //<---CORRECT CONTENT NOW
    spRequest.ContentLength = mailContent.Length;
    Stream newStream = spRequest.GetRequestStream();
    newStream.Write(mailContent, 0, mailContent.Length);
    //...
