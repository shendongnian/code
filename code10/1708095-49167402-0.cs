	public class OutputJson
	{
		public List<string> types { get; set; }
	}
	public string getCodeTypes()
	{
        var objToSerialize = new OutputJson();
		foreach (var key in allKeys)
		{
			objToSerialize.Types.Add(key); 
		}	
		var jsonOutput = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(objToSerialize);
		string finalResposne = JsonConvert.SerializeObject(jsonOutput, Formatting.None);
		return jsonOutput.Replace(@"\", "");
	}
