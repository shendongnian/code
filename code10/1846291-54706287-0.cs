void SetDefaults(object testObj)
{
    var props = testObj.GetType().GetProperties();
    foreach (var prop in props)
    {
        var propType = prop.PropertyType;
        if (propType == typeof(int))
        {
            prop.SetValue(testObj, 1);
        }
        // More conditions...
        else
        {
            var ctor = propType.GetConstructor(Type.EmptyTypes);
            var propertyObject = ctor.Invoke(new object[0]);
            SetDefaults(propertyObject);
            prop.SetValue(testObj, propertyObject);
        }
    }
}
As you can see, if your tree of objects use types that don't have default constructors (parameterless constructors) you need some more complicated logic in the `else`-condition. Basically the stuff going on here is a very simplified version of what happens in a dependency injection framework.
To use it, do something like:
void Main()
{
	TestObject obj = new TestObject();
	SetDefaults(obj);
	
	Console.WriteLine(obj);
}
class TestObject {
	public int MyInt { get; set; }
	public SubTestObject SubObj { get; set; }
}
class SubTestObject {
    public int MyOwnInt { get; set; }
}
