    public class PhoneNumber
    {
        public string Number { get; set; }
    }
    public class Person
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
    }
    IEnumerable<Person> people = new List<Person>();
    // Select gets a list of lists of phone numbers
    IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);
    // SelectMany flattens it to just a list of phone numbers.
    IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);
    // And to include data from the parent in the result: 
    // pass an expression to the second parameter (resultSelector) in the overload:
    var directory = people
       .SelectMany(p => p.PhoneNumbers,
                   (parent, child) => new { parent.Name, child.Number });
