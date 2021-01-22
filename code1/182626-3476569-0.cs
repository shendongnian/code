    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://authcisco/auth.html");
    wr.Method = "POST";
    wr.ContentType = "application/x-www-form-urlencoded";
    string content = string.Format("userName={0}&pass={1}", HttpUtility.UrlEncode(Username), HttpUtility.UrlEncode(Password));
    byte[] data = System.Text.Encoding.ASCII.GetBytes(content);
    wr.ContentLength = data.Length;
    wr.GetRequestStream().Write(data, 0, data.Length);
