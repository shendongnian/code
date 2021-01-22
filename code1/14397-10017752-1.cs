		public class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		public Func<T, TRes> GetPropertyFunc<T, TRes>(string propertyName)
		{
			// get the propertyinfo of that property.
			PropertyInfo propInfo = typeof(T).GetProperty(propertyName);
			// reference the propertyinfo to get the value directly.
			return (obj) => { return (TRes)propInfo.GetValue(obj, null); };
		}
		public void Run()
		{
			List<Person> personList = new List<Person>();
			// fill with some data
			personList.Add(new Person { Name = "John", Age = 45 });
			personList.Add(new Person { Name = "Michael", Age = 31 });
			personList.Add(new Person { Name = "Rose", Age = 63 });
			// create a lookup functions  (should be executed ones)
			Func<Person, string> GetNameValue = GetPropertyFunc<Person, string>("Name");
			Func<Person, int> GetAgeValue = GetPropertyFunc<Person, int>("Age");
			// filter the list on name
			IEnumerable<Person> filteredOnName = personList.Where(item => GetNameValue(item) == "Michael");
			// filter the list on age > 35
			IEnumerable<Person> filteredOnAge = personList.Where(item => GetAgeValue(item) > 35);
		}
