	private void RemoveAllWithName(List<Person> people, string name)
	{
		for(int i = people.Count - 1; i >= 0; --i) {
			Person person = people[i];
			if(person.Name == name) {
				people.RemoveAt(i);
			} else {
				RemoveAllWithName(person.Childs, name);
			}
		}
	}
