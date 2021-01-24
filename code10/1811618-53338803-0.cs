    var requestContent = new MultipartFormDataContent();
    var fileContent = new StreamContent(GetFile.ReadFile());
    requestContent.Add(new StringContent(token), "token");
    requestContent.Add(new StringContent("my_channel"), "channels");
    requestContent.Add(new StringContent("Check out this amazing new file"), "initial_comment");
    requestContent.Add(fileContent, "file", Path.GetFileName(GetFile.path));
