    HttpWebRequest request = (HttpWebRequest)WebRequest.Create (http://www.twitter.com );
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    StreamReader reader = new StreamReader(response.GetResponseStream()); 
    string str = reader.ReadLine();
    while(str != null)
    {
       Console.WriteLine(str);
       str = reader.ReadLine();
    }
