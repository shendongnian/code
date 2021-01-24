	public class MyClass : DefaultedObject<string>
	{
		public string MyStringField;
        protected override string Default => "UNDEFINED";
	}
    
    var myClass = new MyClass();
    // myClass.MyStringField == "UNDEFINED"
