    var data = new[] {
        new BuisnessObject{ Id=1, Name="FOO" },
        new BuisnessObject{ Id=2, Name="BAR" }
    };
    if (data.Any())
    {
        // RowNumber=index or RowNumber=index+1 
        var ouputs = data.Select(
                            (item, index) => 
                            new OuputType {
                               Id=item.Id,
                               Name=item.Name,
                               RowNumber=index 
                            }
                        );
        using (TextWriter writer = new StreamWriter($"OuputFileName.csv"))
        using (var csv = new CsvWriter(writer))
        {
            csv.Configuration.RegisterClassMap<TestMap>();
            csv.WriteHeader<OuputType>();
            csv.NextRecord();
            csv.WriteRecords(ouputs);
        }
    }
    
    public sealed class BuisnessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public sealed class OuputType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RowNumber { get; set; }
    }
    public sealed class TestMap : ClassMap<OuputType>
    {
        public TestMap()
        {
            Map(m => m.Id);
            Map(m => m.Name);
            Map(m => m.RowNumber);
        }
    }
