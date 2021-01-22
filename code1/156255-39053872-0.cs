     //Get the data from text file that needs to be sent.
                    FileStream fileStream = new FileStream(@"G:\Papertest.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    byte[] buffer = new byte[fileStream.Length];
                    int count = fileStream.Read(buffer, 0, buffer.Length);
        
                    //This is a handler would recieve the data and process it and sends back response.
                    WebRequest myWebRequest = WebRequest.Create(@"http://localhost/Provider/ProcessorHandler.ashx");
        
                    myWebRequest.ContentLength = buffer.Length;
                    myWebRequest.ContentType = "application/octet-stream";
                    myWebRequest.Method = "POST";
                    // get the stream object that holds request stream.
                    Stream stream = myWebRequest.GetRequestStream();
                           stream.Write(buffer, 0, buffer.Length);
                           stream.Close();
                
                    //Sends a web request and wait for response.
                    try
                    {
                        WebResponse webResponse = myWebRequest.GetResponse();
                        //get Stream Data from the response
                        Stream respData = webResponse.GetResponseStream();
                        //read the response from stream.
                        StreamReader streamReader = new StreamReader(respData);
                        string name;
                        StringBuilder str = new StringBuilder();
                        while ((name = streamReader.ReadLine()) != null)
                        {
                            str.Append(name); // Add to stringbuider when response contains multple lines data
                       }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
