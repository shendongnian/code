    public class MyClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
	MyClass e = new MyClass();
	IPropertyAccessor[] Accessors = e.GetType().GetProperties()
		.Select(pi => PropertyInfoHelper.CreateAccessor(pi)).ToArray();
	foreach (var Accessor in Accessors)
	{
		Type pt = Accessor.PropertyInfo.PropertyType;
		if (pt == typeof(string))
			Accessor.SetValue(e, Guid.NewGuid().ToString("n").Substring(0, 9));
		else if (pt == typeof(int))
			Accessor.SetValue(e, new Random().Next(0, int.MaxValue));
        Console.WriteLine(string.Format("{0}:{1}",
            Accessor.PropertyInfo.Name, Accessor.GetValue(e)));
	}
