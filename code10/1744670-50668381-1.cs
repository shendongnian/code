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
                var personTag = from a in Parse.String("Person") from b in Parse.LineEnd select a;
                var point = Parse.Char('.');
                Parser<string> nameParser = from tag in Parse.String("name:").Token()
                    from name in Parse.AnyChar.Except(Parse.LineEnd).AtLeastOnce().Text()
                    from le in Parse.LineEnd
                    select name;
                Parser<string> ageParser = from tag in Parse.String("age:").Token()
                    from name in Parse.AnyChar.Except(Parse.LineEnd).AtLeastOnce().Text()
                    from le1 in Parse.LineEnd
                    from del in point
                    from le2 in Parse.LineEnd.Optional()
                    select name;
    
                Parser<Person> personParser =
                    from p in personTag
                    from name in nameParser
                    from age in ageParser
                    select new Person{Name = name, Age = age};
                var personsParser = personParser.Many();
                var persons = personsParser.Parse(Text);
                foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
                }
                Console.ReadLine();
            }
        }
    }
