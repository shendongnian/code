    timer.Start();
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    statusCode = response.StatusCode.ToString();
    
    response.Close();
    
    timer.Stop();
