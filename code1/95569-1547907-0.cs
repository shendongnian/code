    // the class for which to create an UI
    public class MyClass
    {
    	public string Text { get; set; }
    	public int ID { get; set; }
    }
...
	// basic reflection code to build the UI for an object
	var obj = new MyClass() { Text="some text", ID=3};
		
	foreach (var pi in obj.GetType().GetProperties())
	{
		var name = pi.Name;
		var type = pi.PropertyType;
		var value = pi.GetValue(obj, null);
		//now setup the UI control for this property and display the value
	}
		
