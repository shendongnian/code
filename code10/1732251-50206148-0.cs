        class Person {
			public string FirstName;
			public string LastName;
			public Person(string firstName, string lastName) {
				FirstName = firstName;
				LastName = lastName;
			}
		}
		Person[] people = {
			new Person("Fred", "Bloggs"),
			new Person("Linda", "Bloggs"),
			new Person("Joe", "Bloe"),
			new Person("Jane", "Bloe"),
			new Person("Fred", "Flinstone")};
		public void Test() {
			List<Person> list = new List<Person>();		
            // This works	
			var peopleGroupedByLastName = people.GroupBy(k => k.LastName).ToList();
			foreach(var grp in peopleGroupedByLastName) {
				// The grp var holds a list of Person objects, each with the same last name
				list.AddRange(grp); // Pointless, but works
			}
			// The following will not even compile because the anonymous typed objects are
            // not compatible with Person objects, despite having exactly the same fields
			var peopleGroupedByLastName2 = people
				.Select(k => new { FirstName = k.FirstName, LastName = k.LastName })
				.GroupBy(k => k.LastName)
				.ToList();
			foreach(var grp in peopleGroupedByLastName2)
                list.AddRange(grp); // Not "Person" objects
		}
