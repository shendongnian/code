     HttpWebRequest request =(HttpWebRequest)WebRequest.Create("http://www.sina.com.cn");
    HttpWebResponse response =(HttpWebResponse)request.GetResponse();
    long len = response.ContentLength;
    byte[] barr = new byte[len]; 
    response.GetResponseStream().Read(barr, 0, (int)len); 
    response.Close();
    string data = Encoding.UTF8.GetString(barr); 
    var encod = doc.DetectEncodingHtml(data);
    string convstr = Encoding.Unicode.GetString(Encoding.Convert(encod, Encoding.Unicode, barr));
    doc.LoadHtml(convstr);
 
