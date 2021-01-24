        public void ParseJsonResult(string result)
        {
            var definition = new
            {
                ts = "",
                updates = new[]
                {
                    new {
                    attach1_type = "",
                    attach1 = "",
                    title = ""
                   }
                }
            };
            var json = JsonConvert.DeserializeAnonymousType(result, definition);
            json?.updates?.ToList().ForEach(update =>
            {
                var attachment = new Attachment
                {
                    AttachType = update.attach1_type,
                    Attach = update.attach1,
                    Title = update.title,
                };
            });
        }
