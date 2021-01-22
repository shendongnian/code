    public string GetResponse(ArrayObject Parameters)
    {
        // Set the encoding type
        theRequest.ContentType = "application/x-www-form-urlencoded";
            
        theRequest.ContentLength = Parameters.getData().Length;
    
        // We write the parameters into the request
        using (StreamWriter sw = new StreamWriter(theRequest.GetRequestStream()))
        {
            sw.Write(Parameters.getData());
            sw.Flush();
        }
    
        // Execute the query
        theResponse = (HttpWebResponse)theRequest.GetResponse();
        
        using (StreamReader sr = new StreamReader(theResponse.GetResponseStream()))
        {
            return sr.ReadToEnd();
        }
    }
