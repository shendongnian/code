        void SaveUrl(string sourceURL, string savepath) {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sourceURL);
            webRequest.CookieContainer = cookies;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string sResponseHTML = responseReader.ReadToEnd();
            using (StreamWriter sw = new StreamWriter(savepath, false)) {
                sw.Write(sResponseHTML);
            }
            string[] ImageUrl = GetImgLinks(sResponseHTML);
            foreach (string imagelink in ImageUrl) {
                HttpWebRequest imgRequest = (HttpWebRequest)WebRequest.Create(imagelink);
                imgRequest.CookieContainer = cookies;
                HttpWebResponse imgresponse = (HttpWebResponse)imgRequest.GetResponse();
                //Code to save image
            }
        }
