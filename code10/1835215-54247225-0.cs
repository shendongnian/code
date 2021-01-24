    //Define a class to hold all people we get, which might be empty or have problems in them.
    public class PersonText
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ID { get; set; }
        public string ZipCode { get; set; }
        public bool Error { get; set; }
        public bool Anything { get; set; }
    }
    //A class to hold a key ("First Name"), and a way to set the respective item on the PersonText class correctly.
    public class PersonItemGetSets
    {
        public string Key { get; }
        public Func<PersonText, string> Getter { get; }
        public Action<PersonText, string> Setter { get; }
        public PersonItemGetSets(string key, Action<PersonText, string> setter, Func<PersonText, string> getter)
        {
            Getter = getter;
            Key = key;
            Setter = setter;
        }
    }
    
    //This will get people from the lines of text
    public static IEnumerable<PersonText> GetPeople(IEnumerable<string> lines)
    {
        var itemGetSets = new List<PersonItemGetSets>()
        {
            new PersonItemGetSets("First Name", (p, s) =>  p.FirstName = s, p => p.FirstName),
            new PersonItemGetSets("Last Name", (p, s) =>  p.LastName = s, p => p.LastName),
            new PersonItemGetSets("Phone Number", (p, s) =>  p.PhoneNumber = s, p => p.PhoneNumber),
            new PersonItemGetSets("ID", (p, s) =>  p.ID = s, p => p.ID),
            new PersonItemGetSets("Zip Code", (p, s) =>  p.ZipCode = s, p => p.ZipCode),
        };
        foreach (var person in GetRawPeople(lines, itemGetSets, "Error"))
        {
            if (IsValidPerson(person, itemGetSets))
                yield return person;
        }
    }
    //Used to determine if a PersonText is valid and if it is worth processing.
    private static bool IsValidPerson(PersonText p, IReadOnlyList<PersonItemGetSets> itemGetSets)
    {
        if (itemGetSets.Any(x => x.Getter(p) == null))
            return false;
        if (p.Error)
            return false;
        if (!p.Anything)
            return false;
        if (p.PhoneNumber.Length != 12) // "555-555-5555".Length = 12
            return false;
        return true;
    }
    //Read through each line, and return all potential people, but don't validate whether they're correct at this time.
    private static IEnumerable<PersonText> GetRawPeople(IEnumerable<string> lines, IReadOnlyList<PersonItemGetSets> itemGetSets, string errorToken)
    {
        var person = new PersonText();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            bool valid = false;
            if (parts.Length == 2)
            {
                var left = parts[0];
                var right = parts[1].Trim();
                foreach (var igs in itemGetSets)
                {
                    if (left.Equals(igs.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        valid = true;
                        person.Anything = true;
                        if (igs.Getter(person) != null)
                        {
                            yield return person;
                            person = new PersonText();
                        }
                        igs.Setter(person, right);
                    }
                }
            }
            else if (parts.Length == 1)
            {
                if (parts[0].Trim().Equals(errorToken, StringComparison.OrdinalIgnoreCase))
                {
                    person.Error = true;
                }
            }
            if (!valid)
            {
                if (person.Anything)
                {
                    yield return person;
                    person = new PersonText();
                }
                continue;
            }
        }
        if (person.Anything)
            yield return person;
    }
