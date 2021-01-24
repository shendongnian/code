    public sealed class data
    {
        public DateTime TimeStamp { get; set; }
        public List<int> Numbers { get; set; }
    }
    public sealed class dataMapping : ClassMap<data>
    {
        public dataMapping()
        {
            Map(m => m.TimeStamp).Index(0);
            Map(m => m.Numbers)
                .ConvertUsing(
                    row =>
                    new List<int> {
                        row.GetField<int>(1),
                        row.GetField<int>(2),
                        row.GetField<int>(3)
                    }
                );
        }
    }
