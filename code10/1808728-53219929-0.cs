    private async Task<bool> Upload(string filePath)
    {
        const string actionUrl = @"http://126.32.3.178:8111/process/taskmanager/start/start.jsp";
        var fileName = Path.GetFileName(filePath);
        var fileBytes = File.GetAllBytes(filePath);
        var fileContent = new ByteArrayContent(paramFileBytes);
        using (var client = new HttpClient())
        using (var formData = new MultipartFormDataContent())
        {
            formData.Add(fileContent, fileName);
            var response = await client.PostAsync(actionUrl, formData);
            return response.IsSuccessStatusCode;
        }
    }
