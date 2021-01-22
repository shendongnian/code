        string base64string = EncodeTo64(string.Format("{0}:{1}", userName, password));
        string url = "http://nagios/nagios3/";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "Basic " + base64string);
        // execute the request
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Response.Redirect(url);
