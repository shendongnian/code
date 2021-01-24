		static void run()
		{
		    // split with any lib line of CSV
			string[] line = new string[]{"john", "doe", "201"};
			// needed prop names of class
			string[] propNames = "fname|lname|room".Split('|');
			
			Person p = new Person();
			parseLine<Person>(p, line, propNames);
		}
		
		static void parseLine<T>(T t, string[] line, string[] propNames)
		{
			for(int i = 0;i<propNames.Length;i++)
			{
				string sprop = propNames[i];
				PropertyInfo prop = t.GetType().GetProperty(sprop);
				object val = Convert.ChangeType(line[i], prop.PropertyType);
				prop.SetValue(t, val );
			}
		}
		
		class Person
		{
			public string fname{get;set;}
			public string lname{get;set;}
			public int room {get;set;}
		}
