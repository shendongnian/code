    public class MunicipalitiesAndDistrictsNamesIndex : AbstractMultiMapIndexCreationTask<MunicipalitiesAndDistrictsNamesIndex.Result>
    {
        public class Result
        {
            public string Name { get; set; }
    
            public string Value { get; set; }
        }
    
        public MunicipalitiesAndDistrictsNamesIndex()
        {
            AddMap<Municipality>(municipality => from m in municipalities
                select new
                {
                    m.Name,
                    m.Value,
                });
    
            AddMap<Municipality>(municipality => from m in municipalities
                from d in m.Districts
                select new
                {
                    d.Name,
                    d.Value,
                });
    
            // mark 'Name' field as analyzed which enables full text search operations
            Index(x => x.Name, FieldIndexing.Search);
    
            // storing fields so when projection
            // requests only those fields
            // then data will come from index only, not from storage
            Store(x => x.Name, FieldStorage.Yes);
            Store(x => x.Value, FieldStorage.Yes);
        }
    }
