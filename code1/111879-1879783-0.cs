    string URL = Request.Url.AbsoluteUri	
    System.Net.WebClient wc = new System.Net.WebClient();
    string data = wc.DownloadString(URL);
    Response.Output.Write(data);
%>
