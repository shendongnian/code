    void Main()
    {
    	List<MyData> sample = new List<MyData> {
    		new MyData {Id=1, Name="Hammer", Description="Everything looks like a nail to a hammer, doesn't it?"},
    		new MyData {Id=2, Name="C#", Description="A computer language."},
    		new MyData {Id=3, Name="Go", Description="Yet another language, from Google, cross compiles natively."},
    		new MyData {Id=3, Name="BlahBlah"},
    	};
        string fileName = @"c:\temp\MyCSV.csv";
    	
    	File.WriteAllText(fileName,"Id,My Product Name,Ignore1,Ignore2,Description\n");
    	File.AppendAllLines(fileName, sample.Select(s => $@"{s.Id},""{s.Name}"",""ignore this"",""skip this too"",""{s.Description}"""));
    	
    	CsvContext cc = new CsvContext();
    
    	CsvFileDescription inputFileDescription = new CsvFileDescription
    	{
    		SeparatorChar = ',',
    		FirstLineHasColumnNames = true, 
    		IgnoreUnknownColumns=true
    	};
    
    	IEnumerable<MyData> fromCSV = cc.Read<MyData>(fileName, inputFileDescription);
        
    	foreach (var d in fromCSV)
    	{
    		Console.WriteLine($@"ID:{d.Id},Name:""{d.Name}"",Description:""{d.Description}""");
    	}
    }
    
    public class MyData
    {
    	[CsvColumn(FieldIndex = 1, Name="Id", CanBeNull = false)]
    	public int Id { get; set; }
    	[CsvColumn(FieldIndex = 2, Name="My Product Name",CanBeNull = false, OutputFormat = "C")]
    	public string Name { get; set; }
    	[CsvColumn(FieldIndex = 5, Name="Description",CanBeNull = true, OutputFormat = "C")]
    	public string Description { get; set; }
    }
