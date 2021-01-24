            public static void FileCopy(string source, string dest, string webhookurl)
        {
            using (var client = new WebClient { Headers = { [HttpRequestHeader.ContentType] = "application/json" } })
            {
                var paramRecord = new Parameters(source, dest);
                var serializer = new DataContractJsonSerializer(typeof (Parameters));
                var memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, paramRecord);
                // todo handle the removal of escaped strings better
                var jsonObject = Encoding.Default.GetString(memoryStream.ToArray()).Replace(@"\", "");
                string response = client.UploadString(webhookurl, jsonObject);
            }
        }
