    string headername = "TokenName";
    string headervalue = "0000000000";
    var request = (HttpWebRequest)WebRequest.Create("https://URL");
    request.Method = "DELETE";
    request.Headers.Add(headername, headervalue);
    try
    {
        var response = (HttpWebResponse)request.GetResponse();
        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        var jss = new JavaScriptSerializer();
        var dict = jss.Deserialize<dynamic>(responseString);
        string message += "deleted Item with id" + dict["id"];
    }
    catch
    {
        string message += "Didn't delete Item";
    }
