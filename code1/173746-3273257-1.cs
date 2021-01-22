    HttpWebResponse webresponse;
    webresponse = (HttpWebResponse)webrequest.GetResponse();
    Encoding enc = System.Text.Encoding.GetEncoding(1252);
    StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(),enc);
    string Response = loResponseStream.ReadToEnd();
    loResponseStream.Close();
    webresponse.Close();
    return Response;
