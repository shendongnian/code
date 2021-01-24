	void Main()
	{
		// import Newtonsoft.JsonConvert
		
		SecondClass secondClass = new SecondClass
		{
			Value = "Test"
		};
	
		MainClass mainClass = new MainClass
		{
			MyStringValue = "String Value",
			MyClassValue = secondClass
		};
		
		// The JSON as you expect
		var origJson = JsonConvert.SerializeObject(mainClass);
		Console.WriteLine(origJson);
		// The JSON Deserialized and the second class value outputted
		Console.WriteLine(JsonConvert.DeserializeObject<MainClass>(origJson).MyClassValue.Value);
	
		// The modified JSON as you wanted it
		var modJson = JsonConvert.SerializeObject(new { mainClass.MyStringValue, MyClassValue = mainClass.MyClassValue.Value });
		Console.WriteLine(modJson);
				
		// The modified JSON deserialized
		var deserialized = JsonConvert.DeserializeObject<ModMainClass>(modJson);
		Console.WriteLine(deserialized.MyStringValue);
	}
	
	public class ModMainClass
	{
		public string MyStringValue { get; set; }
		public string MyClassValue { get; set; }
	}
	
	public class MainClass
	{
	   public string MyStringValue {get;set;}
	   public SecondClass MyClassValue {get;set;}
	}
	
	public class SecondClass
	{
		public string Value { get; set; }
	} 
