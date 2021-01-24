    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var writer = new StreamWriter(stream))
    	using (var reader = new StreamReader(stream))
    	using (var csv = new CsvWriter(writer))
    	{
    		var records = new List<Test>
    		{
    			new Test { Id = 1, Name = "one" },
    			new Test { Id = 2, Name = null },
    		};
    
    		csv.Configuration.RegisterClassMap<TestMap>();
    		csv.WriteRecords(records);
    		
    		writer.Flush();
    		stream.Position = 0;
    		
    		reader.ReadToEnd().Dump();
    	}
    }
    
    public class Test
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public sealed class TestMap : ClassMap<Test>
    {
    	public TestMap()
    	{
    		Map(m => m.Id);
    		Map(m => m.Name).TypeConverter<CustomNullTypeConverter<string>>();
    	}
    }
    
    public class CustomNullTypeConverter<T> : DefaultTypeConverter
    {
    	public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    	{
    		if (value == null)
    		{
    			return "#NULL#";
    		}
    		
    		var converter = row.Configuration.TypeConverterCache.GetConverter<T>();
    		return converter.ConvertToString(value, row, memberMapData);
    	}
    }
