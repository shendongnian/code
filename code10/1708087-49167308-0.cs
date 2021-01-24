	public class OutputJson
    {
        public List<string> types { get; set; }
    }
	OutputJson json = new OutputJson
	{
		types = new List<string> {"KKYQ", "TGDF", "YHGF"}
	};
	string finalResposne = JsonConvert.SerializeObject(json);
