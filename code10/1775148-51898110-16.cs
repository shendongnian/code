        public void ParseJsonResult(SomethingJsonResult result)
        {
            var definition = new
                {
                    attach1_type = "",
                    attach1 = "",
                    title = ""
                };
            
            result?.updates?.ForEach(x =>
            {
                var update = JsonConvert.DeserializeAnonymousType(x[6], definition);
                var attachment = new Attachment
                {
                    AttachType = update.attach1_type,
                    Attach = update.attach1,
                    Title = update.title,
                };
            });
        }
