    private string getTimeLine()
    {
        string responseValue = "";
        string aUrl = "http://168.143.162.116/statuses/home_timeline.xml";
        AutoResetEvent syncRequest = new AutoResetEvent(false);
        WebRequest request = WebRequest.Create(aUrl);
        request.Method = "POST";
        request.BeginGetResponse(getResponseResult =>
        {
            HttpWebResponse response = 
                (HttpWebResponse)request.EndGetResponse(getResponseResult);
            using (StreamReader reader = 
               new StreamReader(response.GetResponseStream()))
            {
                responseValue = reader.ReadToEnd();
            }
            
            syncRequest.Set();
        }, null);
        syncRequest.WaitOne();
        return responseValue;
    }
