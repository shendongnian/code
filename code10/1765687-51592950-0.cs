            string json = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlJSONcall);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                if ((responseStream != null) && responseStream.CanRead)
                {
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        json = reader.ReadToEnd();
                        
                    }
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            var datao = (JObject)JsonConvert.DeserializeObject(json);
            //LBresponse.Text = data.ToString();
            string urll = (string)datao["request"]["files"]["progressive"][0]["url"];
            string thumbnailImage = (string)datao["video"]["thumbs"]["640"];
            LBresponse.Text = urll.ToString();
            lbltumb.Text = thumbnailImage.ToString();
        }
