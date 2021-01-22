    private class CsvPersonMapping : CsvMapping<Person>
    {
        public CsvPersonMapping()
            : base()
        {
            MapProperty(0, x => x.FirstName);
            MapProperty(1, x => x.LastName);
            MapProperty(2, x => x.BirthDate);
        }
    }
