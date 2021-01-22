    PersonFinder finder = new PersonFinder();
    finder.nameToFind = ...
    Person found = people.Find(finder.IsMatch);
    ...
    class PersonFinder {
        public string nameToFind; // a public field to mirror the C# capture
        public bool IsMatch(Person person) {
            return person.Name == nameToFind;
        }
    }
