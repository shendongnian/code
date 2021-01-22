            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.siteiwanttofindnumberon.com/pagetoopen.html");
            request.Headers = new WebHeaderCollection();
            //set up headers as necessary
            request.Method = "GET";
            //retrieve the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            b = new List<byte>();
            while (b.Count < request.ContentLength)
                b.Add((byte)response.GetResponseStream().ReadByte());
