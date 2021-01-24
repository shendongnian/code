    public bool Find(List<string> nameList, List<Person> personList)
		{
			foreach (var name in nameList)
				if (personList.FirstOrDefault(person => person.Name == name) != null)
				{
					// Find
					return true;
				}
			return false;
		}
