	private class MyClass : DefaultedObject<string>
	{
		public string MyStringField { get; set; }
        protected override string Default => "UNDEFINED";
	}
    
    var myClass = new MyClass();
    // myClass.MyStringField == "UNDEFINED"
