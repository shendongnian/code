    public async Task<bool> CollectAndUpdateNorwegianCompanyRegistry()
    {
        using (var stream = await _httpClient.GetStreamAsync(_options.Value.Urls["BrregCsv"]))
        using (var streamReader = new StreamReader(stream))
        using (var csv = new CsvReader(streamReader))
        {
            csv.Configuration.Delimiter = ";";
            csv.Configuration.BadDataFound = null;
            csv.Configuration.RegisterClassMap<NorwegianCompanyClassMap>();
            
            await _sqlRepository.UpdateNorwegianCompaniesTable(csv.GetRecords<NorwegianCompany>());
        }
        return true;
    }
