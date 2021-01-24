    public class Program
    {
    	public static void Main()
    	{
    		var json = "[{ coordinates: [-74, 40.7], values: [22.4, 23.2, 21.5, 20.6,12.3], }, { coordinates: [-77, 38.90], values: [13.4, 18.2, 24.5, 10.6, 16.3], }, { coordinates: [-87, 41.88], values: [39.3, 28.8, 10.4, 20.0, 0], }]";
    		
    		var mapDataLists = JsonConvert.DeserializeObject<List<MapDataList>>(json);
    				
    		var coordinates = mapDataLists.SelectMany(d => d.coordinates);
    		var values = mapDataLists.SelectMany(d => d.values);
    		
    		Console.WriteLine("Coordinates");
    		foreach(var d in coordinates){
    			Console.WriteLine(d);
    		}
    		
    		Console.WriteLine("Values");
    		foreach(var d in coordinates){
    			Console.WriteLine(d);
    		}
    	}
    }
    public class MapDataList
    {
        public List<double> coordinates { get; set; }
        public List<double> values { get; set; }
    }
