        public List<List<string>> updates { get; set; }//change above object to string
        public void ParseJsonResult(SomethingJsonResult result)
        {
            var definition = new //define your json structure
            {
                attach1_type = "",
                attach1 = "",
                title = ""
            };
            result?.updates?.ForEach(update =>
            {
                var json = JsonConvert.DeserializeAnonymousType(update[6], definition);
                //convert json structure to real data entity
                var attachment = new Attachment
                {
                    AttachType = json.attach1_type,
                    Attach = json.attach1,
                    Title = json.title,
                };
            });
        }
