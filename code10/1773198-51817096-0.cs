        HttpWebRequest webRequest;
        void StartWebRequest(string imgUrl)
        {
            webRequest = WebRequest.CreateHttp(imgUrl);
            webRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
        }
        void FinishWebRequest(IAsyncResult result)
        {
            HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            Task.Run(() =>
            {
                using (var str = response)
                {
                    addTablePic.BeginInvoke((MethodInvoker)delegate () { addTablePic.Image = Image.FromStream(str); });
                }
            });
        }
