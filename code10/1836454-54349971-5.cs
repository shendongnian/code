    public async Task SplitCsvData(IFormFile file, string uid)
        {
            var data = string.Empty;
            var m = new List<string>();
            var r = new List<string>();
            var records = new List<string>();
            using (var stream = file.OpenReadStream())
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var header = line.Split(',')[0].ToString();
                    bool parsed = int.TryParse(header, out int result);
                    if (!parsed)
                    {
                        m.Add(line);
                    }
                    else
                    {
                        r.Add(line);
                    }
                }
            }
            //TODO: Validation
            //This splits the list into the Meta data model. This is just a single object, with static fields.
            var metaData = SplitCsvMetaData.SplitMetaData(m, uid);
            DataTable dtm = CreateMetaData(metaData);
            var serialNumber = metaData.LoggerId;
            await SaveMetaData("MetaData", dtm);
            //
            var lrd = new List<RawDataModel>();
            foreach (string row in r)
            {
                lrd.Add(new RawDataModel
                {
                    Id = 0,
                    SerialNumber = serialNumber,
                    ReadingNumber = Convert.ToInt32(row.Split(',')[0]),
                    ReadingDate = Convert.ToDateTime(row.Split(',')[1]).ToString("yyyy-MM-dd"),
                    ReadingTime = Convert.ToDateTime(row.Split(',')[2]).ToString("HH:mm:ss"),
                    RunTime = row.Split(',')[3].ToString(),
                    Temperature = Convert.ToDouble(row.Split(',')[4]),
                    ProjectGuid = uid.ToString(),
                    CombineDateTime = Convert.ToDateTime(row.Split(',')[1] + " " + row.Split(',')[2]).ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
                   
            await SaveRawData("RawData", lrd);
        }
