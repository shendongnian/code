        [HttpPost]
        public HttpWebResponseResult RelayPost()
        {
            var postRequest = (HttpWebRequest)WebRequest.Create("http://www.fissio.com/pirate.pl");
            postRequest.Method = "POST";
            // Relay content stream
            this.Request.InputStream.CopyTo(postRequest.GetRequestStream());
            var response = (HttpWebResponse)postRequest.GetResponse();
            return new HttpWebResponseResult(response);
        }
