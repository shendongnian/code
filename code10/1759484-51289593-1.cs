    void Main()
    {
    	var x = new Car();
    	x.Drivers.Add(new Driver { Id = 1 });
    	var dataSet = AsDataSet(x);
    	Console.WriteLine($"PrimaryDriver: {dataSet.Tables["PrimaryDriver"].Rows.Count}");
    	Console.WriteLine($"Drivers: {dataSet.Tables["Drivers"].Rows.Count}");
    	
    	// Output:
    	// PrimaryDriver: 1
    	// Drivers: 1
    }
    
    [Serializable]
    public class Car
    {
    	public Driver PrimaryDriver = new Driver();
    	public List<Driver> Drivers = new List<Driver>();
    }
    
    [Serializable]
    public class Driver
    {
    	public int Id { get; set; }
    }
    
    private static DataSet AsDataSet(Car ceInv)
    {
    	var serializer = new XmlSerializer(ceInv.GetType());
    	var ms = new MemoryStream();
    	serializer.Serialize(ms, ceInv);
    	ms.Position = 0;
    	var ds = new DataSet();
    	//Console.WriteLine($"{new StreamReader(ms).ReadToEnd()}"); ms.Position = 0; // DEBUGGING
    	ds.ReadXml(ms);
    	return ds;
    }
