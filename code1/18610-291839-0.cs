    Image someImage = Image.FromFile("mypic.jpg");
    // Firstly, get the image as a base64 encoded string
    ImageConverter imageConverter = new ImageConverter();
    byte[] buffer = (byte[])imageConverter.ConvertTo(someImage, typeof(byte[]));
    string base64 = Convert.ToBase64String(buffer, Base64FormattingOptions.InsertLineBreaks);
    // Then, dynamically create some XHTML for this (as this is just a sample, minimalistic XHTML :D)
    string html = "<img src=\"data:image/" . someImage.RawFormat.ToString() . ";base64, " . $base64 . "\">";
    // And put it into some stream
    using (StreamWriter streamWriter = new StreamWriter(new MemoryStream()))
    {
        streamWriter.Write(html);
        streamWriter.Flush();
        webBrowser.DocumentStream = streamWriter.BaseStream;
        webBrowser.DocumentType = "text/html";
    }
