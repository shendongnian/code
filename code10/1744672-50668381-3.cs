    using System;
    using System.Collections.Generic;
    using Sprache;
    namespace SplitTextSample
    {
        class Program
        {
            public static string Text =
    @"Person
    name: abc
    age: 40
    .
    Person
    name: xyx
    age: 18
    .
    Person
    name: uke
    age: 27
    .";
            public class Person
            {
                public string Name { get; set; }
                public string Age { get; set; }
            }
            static void Main(string[] args)
            {
                // Parses: Person\r\n
                var personTagParser = Parse.String("Person").Then(_=>Parse.LineEnd);
                // Parses: name: {name}\r\n
                Parser<string> nameParser = from tag in Parse.String("name:").Token()
                    from name in Parse.AnyChar.Except(Parse.LineEnd).AtLeastOnce().Text()
                    from lineEnd in Parse.LineEnd
                    select name;
                // Parses: age: {age}\r\n.[\r\n]
                Parser<string> ageParser = from tag in Parse.String("age:").Token()
                    from age in Parse.AnyChar.Except(Parse.LineEnd).AtLeastOnce().Text()
                    from delimeter in Parse.LineEnd.Then(_ => Parse.Char('.')).Then(_=> Parse.LineEnd.Optional())
                    select age;
                // Parses: Person\r\nname: {name}\r\nage: {age}\r\n.[\r\n]
                Parser<Person> personParser =
                    from personTag in personTagParser
                    from name in nameParser
                    from age in ageParser
                    select new Person{Name = name, Age = age};
                // Parses: Many persons
                var personsParser = personParser.Many();
                // Final parse returns IEnumerable<Person>
                var persons = personsParser.Parse(Text);
                foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
                }
                Console.ReadLine();
            }
    }
