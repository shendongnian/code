    using (WebClient client = new WebClient())
    {
        client.Credentials = new NetworkCredential("log", "pass");
        client.UploadFile("your_server", "STOR", filePath);
    }
