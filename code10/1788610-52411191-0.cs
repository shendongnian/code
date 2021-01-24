    using (var client = new HttpClient())
    {
        MultipartFormDataContent form = new MultipartFormDataContent();
        var uri = new StringBuilder(_domain).Append("/api/data/send");
        client.Timeout = Timeout.InfiniteTimeSpan;
        //adding all properties to the form
        if (!String.IsNullOrEmpty(model.SenderAddress))
            form.Add(new StringContent(model.SenderAddress), "SenderAddress");  
        if (model.Attachments.FirstOrDefault() != null)
        {
            foreach (var attachment in model.Attachments)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(attachment.InputStream))
                {
                    fileData = binaryReader.ReadBytes(attachment.ContentLength);
                }
                form.Add(new ByteArrayContent(fileData, 0, fileData.Length), "Attachments", attachment.FileName);
             }
         }
                    
        HttpResponseMessage response = await client.PostAsync(uri.ToString(), form);
        response.EnsureSuccessStatusCode();
        string result = response.Content.ReadAsStringAsync().Result;
        if (response.StatusCode == HttpStatusCode.OK)
            return Request.CreateResponse(response.StatusCode, "Successfully Sent!");
        else
            return Request.CreateResponse(response.StatusCode, result);          
    }
