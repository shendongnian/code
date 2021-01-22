    string getHtml(string url)
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myWebRequest.Method = "GET";
                // make request for web page
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                StreamReader myWebSource = new StreamReader(myWebResponse.GetResponseStream());
                string myPageSource = string.Empty;
                myPageSource = myWebSource.ReadToEnd();
                myWebResponse.Close();
                return myPageSource;
            }
