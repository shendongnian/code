      private struct QueryResponse
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
                    
                        QueryResponse queryResponse = JsonConvert.DeserializeObject<QueryResponse>(mycontent.Result);
                        string id = queryResponse.id;
                        string operation = queryResponse.operation;
                        VoiceIA voiceObj = queryResponse.VoiceIAQStats;
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
