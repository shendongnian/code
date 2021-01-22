	public class Person
	{
		public string LastName;
		public string FirstName;
	}
	public class Class2
	{
		public void test()
		{
			List<Person> classList = new List<Person>();
			//add some data to the list
			PersonComparer comp = new PersonComparer();
			classList.Sort(comp);
		}
	}
	public class PersonComparer : Comparer<Person>
	{
		public override int Compare(Person x, Person y)
		{
			int val = x.LastName.CompareTo(y.LastName);
			if (val == 0)
			{
				val = x.FirstName.CompareTo(y.FirstName);
			}
			return val;
		}
	}
