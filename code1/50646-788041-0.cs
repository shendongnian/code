        // Create a request using a URL that can receive a post. 
    WebRequest request = WebRequest.Create("http://sharepointsite/somefile.txt");
    
    // Set the Method property of the request to POST.
    request.Method = "PUT"
    
    Stream dataStream;
    
    // Set the ContentType property of the WebRequest.
    request.ContentType = "multipart/form-data; charset=ISO-8859-1";
    
    byte[] byteArray = File.ReadAllBytes(@"c:\somefile.txt");
    
    // Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length;
    
    // Get the request stream.
    dataStream = request.GetRequestStream();
    
    // Write the data to the request stream.
    dataStream.Write(byteArray, 0, byteArray.Length);
    
    // Close the Stream object.
    dataStream.Close();
    
    // Get the response.
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    HttpStatusCode statCode = response.StatusCode;
    
    // Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader(dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd();
    
    // Clean up the streams.
    reader.Close();
    dataStream.Close();
    response.Close();
