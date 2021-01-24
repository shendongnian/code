    WebClient client = new WebClient();
    var nameValue = new NameValueCollection();
    nameValue.Add("entry.xxx", "VALUE");// You will find these in name (not id) attributes of the input tags 
    nameValue.Add("entry.xxx", "VALUE");
    nameValue.Add("entry.xxx", "VALUE");
    nameValue.Add("entry.xxx", "VALUE");
    nameValue.Add("pageHistory", "0,1,2");//Comma separated page indexes
    Uri uri = new Uri("https://docs.google.com/forms/d/e/[FORM_ID]/formResponse");
    byte[] response = client.UploadValues(uri, "POST", nameValue);
    string result = Encoding.UTF8.GetString(response);
