    var ms = new MemoryStream();
    ms.Write(Encoding.ASCII.GetBytes(@"--AaB03x
    Content-Disposition: form-data; name=""submit-name""
    "));
    ms.Write(Encoding.ASCII.GetBytes(@"Larry
    "));
    ms.Write(Encoding.ASCII.GetBytes(@"--AaB03x
    Content-Disposition: form-data; name=""files""; filename=""file1.txt""
    Content-Type: text/plain
    "));
    // ... write contents of file1.txt ...
    ms.Write(Encoding.ASCII.GetBytes(@"--AaB03x--
    "));
    WebClient myWebClient = new WebClient();
    myWebClient.Headers.Add("Content-Type", "multipart/form-data; boundary=AaB03x");
    myWebClient.UploadData(uriString, ms.ToArray());
