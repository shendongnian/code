    public class Item
	{
		[JsonProperty("Na")]
		public string Na { get; set; }
	}
	public class Data
	{
		[JsonProperty("total")]
		public int total { get; set; }
		[JsonProperty("items")]
		public IList<Item> items { get; set; }
	}
	public class Example
	{
		[JsonProperty("data")]
		public Data data { get; set; }
	}
And then deserialize the data-
	var data = JsonConvert.Deserialize<Example>("{ \"data\": ...... ")
Now you can get the data using the object `data`. `data.Items`, `data.Total`.
So you can write -
foreach( var item in data.Items){
    var toal = data.total;
    var na = item.Na;
}
2. Alternatively, If you only need to do is to get the values, you can use `dynamic`.
var data = JsonConvert.Deserialize<dynamic>("{ \"data\": ...... ");
var items = data.items;
var total = data.total;
....
foreach( var item in data.Items){
    var toal = data.total;
    var na = item.Na;
}
but for this approach you have to cast them again whenever you use them.
I hope this helps. If this is not something you are looking for, let me know.
