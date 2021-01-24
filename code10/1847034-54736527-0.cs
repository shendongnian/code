    public async Task<bool> CollectAndUpdateNorwegianCompanyRegistryAlternate()
    {
        using (var stream = await _httpClient.GetStreamAsync(_options.Value.Urls["BrregCsv"]))
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.RegisterClassMap<NorwegianCompanyClassMap>();
            csv.Configuration.Delimiter = ";";
            csv.Configuration.BadDataFound = null;
            var tempList = new List<NorwegianCompany>();
            while (csv.Read())
            {
                tempList.Add(csv.GetRecord<NorwegianCompany>());
                
                if (tempList.Count() > 50000)
                {
                    await Task.Factory.StartNew(() => _sqlRepository.UpdateNorwegianCompaniesTable(tempList));
                    
                    tempList.Clear();
                }
            }
        }
        return true;
    }
