    var client = new HttpClient();
    
    var queryString = HttpUtility.ParseQueryString(string.Empty);
    
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{Subscription_Key_here}");
    
    queryString["mode"] = "Printed";
    
    var uri = "https://{region}.api.cognitive.microsoft.com/vision/v2.0/recognizeText?" + queryString;
    
    HttpResponseMessage response;
    
    var imagePath = @"D:\xxx\xxx\xxx\testcontent.PNG";
    
    Stream imageStream = File.OpenRead(imagePath);
    
    BinaryReader binaryReader = new BinaryReader(imageStream);
    
    byte[] byteData = binaryReader.ReadBytes((int)imageStream.Length);
    
    using (var content = new ByteArrayContent(byteData))
    {
        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        response = await client.PostAsync(uri, content);
    
        if (response.IsSuccessStatusCode)
        {
            var contentString = await response.Content.ReadAsStringAsync();
    
            var operation_location = response.Headers.GetValues("Operation-Location").FirstOrDefault();
    
            Console.WriteLine($"Response content is empty({contentString == string.Empty}).\n\rYou should further query the operation status using the URL ({operation_location}) specified in response header.");
        }
    }
