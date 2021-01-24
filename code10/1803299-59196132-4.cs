    public class StringClobMap : ClassMap<StringClob>
    {
        public StringClobMap()
        {
            Id(x => x.Value, "VALUE").CustomType("StringClob").CustomSqlType("VARCHAR(MAX)").Length(int.MaxValue / 2);
        }
    }
