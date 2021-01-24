    public List<Data.Country> GetCountryData(string filePath)
        {
            string csvRead = File.ReadAllText(filePath);
            string[] csvFileRecord = csvRead.Split('\n');
            List<Data.Country> dataRecordList = new List<Data.Country>();
    
            foreach (var row in csvFileRecord.Skip(1))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var cells = row.Split(',');
                    var dataRecord = new Data.Country
                    {
                        Id = Guid.Parse(cells[0]),
                        Code = cells[1],
                        Name = cells[2]
                    };
                    dataRecordList.Add(dataRecord);
                }
            }
    
            return dataRecordList;
        }
