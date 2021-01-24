    public override async Task<ValidateResult> ValidateAsync<T>(IField<T> field, T state)
    {
        var result = await base.ValidateAsync(field, state);
    
        if (result.IsValid)
        {
            var isValidForMe = this.Attachment.ContentType.ToLowerInvariant().Contains("image/png");
    
            if (!isValidForMe)
            {
                result.IsValid = false;
                result.Feedback = $"Hey, dude! Provide a proper 'image/png' attachment, not any file on your computer like '{this.Attachment.Name}'!";
            }
            else
            {
                var url = this.Attachment.ContentUrl;
    
                HttpClient httpClient = new HttpClient();
                Stream filestrem = await httpClient.GetStreamAsync(url);
                httpClient.Dispose();
    
                byte[] ImageAsByteArray = null;
                        
                using (MemoryStream ms = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        byte[] buf = new byte[1024];
                        count = filestrem.Read(buf, 0, 1024);
                        ms.Write(buf, 0, count);
                    } while (filestrem.CanRead && count > 0);
                    ImageAsByteArray = ms.ToArray();
                }
    
                HttpClient client = new HttpClient();
    
                // Request headers.
                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", "{Subscription_Key_here}");
    
                // Request parameters. A third optional parameter is "details".
                string requestParameters =
                    "visualFeatures=Categories";
    
                // Assemble the URI for the REST API Call.
                string uri = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze?" + requestParameters;
    
                HttpResponseMessage response;
    
    
                using (ByteArrayContent content = new ByteArrayContent(ImageAsByteArray))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");
    
                    // Make the REST API call.
                    response = await client.PostAsync(uri, content);
                }
    
                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();
    
                var rs = Newtonsoft.Json.Linq.JToken.Parse(contentString);
    
                        
                if (rs.HasValues)
                {
                    string val = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)rs).First).First).First).First).Value).Value.ToString();
    
                    if (val!= "people_")
                    {
                        result.IsValid = false;
                        result.Feedback = $"The image '{this.Attachment.Name}' is not a person's image!";
                    }
                }
    
            }
        }
    
        return result;
    }
