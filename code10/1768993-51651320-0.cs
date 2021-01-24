    void Main()
    {
    	List<MyData> sample = new List<MyData> {
    		new MyData {Id=1, Name="Hammer", Description="Everything looks like a nail to a hammer, doesn't it?"},
    		new MyData {Id=2, Name="C#", Description="A computer language."},
    		new MyData {Id=3, Name="Go", Description="Yet another language, from Google, cross compiles natively."},
    	};
        string fileName = @"c:\temp\MyCSV.csv";
    	
    	File.WriteAllText(fileName,"Id,Name,Description\n");
    	File.AppendAllLines(fileName, sample.Select(s => $@"{s.Id},""{s.Name}"",""{s.Description}"""));
    	
    	CsvContext cc = new CsvContext();
    
    	CsvFileDescription inputFileDescription = new CsvFileDescription
    	{
    		SeparatorChar = ',',
    		FirstLineHasColumnNames = true
    	};
    
    	IEnumerable<MyData> fromCSV = cc.Read<MyData>(fileName, inputFileDescription);
        
    	foreach (var d in fromCSV)
    	{
    		Console.WriteLine($@"ID:{d.Id},Name:""{d.Name}"",Description:""{d.Description}""");
    	}
    }
    
    public class MyData
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    }
