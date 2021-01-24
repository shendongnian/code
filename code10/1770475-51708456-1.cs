        [HttpPost]
        public HttpResponseMessage LoginMethod(Dictionary<string, string> postParams = null)
        {
            HttpRequestMessage re = Request;
            re.Content = new FormUrlEncodedContent(postParams);
            var payLoadJson = re.Content;
            string jsonContent = await payLoadJson.ReadAsStringAsync().ConfigureAwait(false);            
            var test = JObject.Parse(jsonContent);
            string userid = JObject.Parse(jsonContent)["MyFirstValue"].ToString();
            var password = JObject.Parse(jsonContent)["MySecondValue"].ToString();
          //Rest of operation
        }
