     private struct ResponseData
        {
            public List<Data> results { get; set; }
        }
        private struct Data
        {
            public string id { get; set; }
            public string operation { get; set; }
            public VoiceIA VoiceIAQStats { get; set; }
        }
        private struct VoiceIA
        {
            [JsonProperty("id")]
            public long id { get; set; }
            [JsonProperty("esdId")]
            public long esdId { get; set; }
            [JsonProperty("esdName")]
            public string esdName { get; set; }
        }
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))//  .GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        var mycontent = content.ReadAsStringAsync();
                        ResponseData queryResponse = JsonConvert.DeserializeObject<ResponseData>(mycontent.Result);
                        string id = queryResponse.results[0].id;
                        int count = queryResponse.results.Count;
                        string operation = queryResponse.results[0].operation;
                        VoiceIA voiceObj = queryResponse.results[0].VoiceIAQStats;
                        long idOfVoice = voiceObj.id;
                        long esdId = voiceObj.esdId;
                        string esdName = voiceObj.esdName;
                        ////                            Console.WriteLine(mycontent);
                        //JArray a = JArray.Parse(mycontent);
                        //Console.WriteLine("Total Count is " + a.Count());
                        //Console.WriteLine("Data is " + a.ToString());
                    }
                }
            }
        }
