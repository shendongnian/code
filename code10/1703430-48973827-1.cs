	string json = "{\"result\":[]}\r\n{\"result\":[{\"alternative\":[{\"transcript\":\"distance between the trees\",\"confidence\":0.46962094},{\"transcript\":\"Justin prescription that reason\"},{\"transcript\":\"Justin Swift accessories\"},{\"transcript\":\"justice respiratory\"},{\"transcript\":\"Justin syska accessories\"}],\"final\":true}],\"result_index\":0}";
	string trueJson = json.Split(new[] { Environment.NewLine }, StringSplitOptions.None)[1];
	try
	{
		RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(trueJson);
		rootObject = rootObject;
	}
	catch (Exception ex)
	{	   
		throw;
	}
	public class Alternative
	{
		public string transcript { get; set; }
		public double confidence { get; set; }
	}
	public class Result
	{
		public List<Alternative> alternative { get; set; }
		public bool final { get; set; }
	}
	public class RootObject
	{
		public List<Result> result { get; set; }
		public int result_index { get; set; }
	}  
	  
