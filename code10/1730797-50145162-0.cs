    var content = JsonConvert.SerializeObject(myDetails); //myDetails is my class object.
    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
    var byteContent = new ByteArrayContent(buffer);
    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");   
     var response = await client.PostAsync(url, byteContent);
