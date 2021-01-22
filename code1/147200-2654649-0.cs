    public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Title { get; set; }
			public DateTime BirthDate { get; set; }
			public DateTime HireDate { get; set; }
			public string City { get; set; }
			public string Region { get; set; }
		}
		public void Parse(string csv)
		{
			string[] lines = csv.Split( Environment.NewLine.ToCharArray() );
                        List<Person> persons = new List<Person>();
			foreach (string line in lines)
			{
				string[] values = line.Split( ',' );
				Person p = new Person();
				p.FirstName = values[ 0 ];
				p.LastName = values[ 1 ];
                                persons.Add( p );
				//.... etc etc
			}
		}
