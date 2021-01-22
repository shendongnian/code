    static IEnumerable<Person> ReadPeople(string path) {
        using(var reader = File.OpenText(path)) {
            string line;
            while((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(',');
                yield return new Person(parts[0], int.Parse(parts[1]);
            }
        }
    }
