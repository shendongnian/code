    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUrl);
    System.Diagnostics.Stopwatch timer = new Stopwatch();
    
    timer.Start();
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    statusCode = response.StatusCode.ToString();
    
    response.Close();
    
    timer.Stop();
