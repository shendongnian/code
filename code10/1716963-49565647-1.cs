	private class MyClass : DefaultedObject<string>
	{
		public string MyStringField { get; set; }
		protected override string Default()
		{
			return "UNDEFINED";
		}
	}
    
    var myClass = new MyClass();
    string value = myClass.MyStringField;
    // value == "UNDEFINED"
