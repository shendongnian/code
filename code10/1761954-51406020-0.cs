    var fileStatusList = new List<FileStatusDetail>();
            var storage = new S3Manager();
            foreach (string s in objectType)
            {
                var fileData = storage.GetS3(s, organisationCode);
                if (fileData != null)
                {
                    var parsedObject = JObject.Parse(fileData);
                    var parsedJson = parsedObject["meta"].ToString();
                    var json = JsonConvert.DeserializeObject<Metadata>(parsedJson);
                    fileStatusList.Add(new FileStatusDetail
                    {
                        source = s,
                        RecordCount = json.RecordCount,
                        RefreshDate = json.CreatedDate
                    });
                }
            }
