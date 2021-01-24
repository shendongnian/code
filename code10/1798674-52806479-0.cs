        using (var client = new HttpClient())
        {
            var requestContent = new MultipartFormDataContent("UPLOAD ID");
            byte[] fileBytes = null;// some image
            var imgCnt = new ByteArrayContent(fileBytes);
            imgCnt.Headers.Add("Content-Transfer-Encoding", "binary");
            imgCnt.Headers.Add("Content-Type", "application/octet-stream");
            requestContent.Add(imgCnt, "photo", $"{Path.GetRandomFileName()}.jpg");
            var progressContent = new ProgressableStreamContent(requestContent, 1024, progress);
            var req = await client.PostAsync(new Uri("SOME URI"), progressContent);
        }
