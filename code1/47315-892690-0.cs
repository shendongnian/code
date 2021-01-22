    using (WebClient client = new WebClient())
    {
        client.UseDefaultCredentials = Program.WebService.UseDefaultCredentials;
        client.Credentials = Program.WebService.Credentials;
        client.UploadFile(uploadUrl, "PUT", localFile);
    }
