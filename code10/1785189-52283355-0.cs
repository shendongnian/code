    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    using Newtonsoft.Json;
    
    namespace ConsoleApp1 {
        class Program {
            static void Main(string[] args) {
    
                // Just get your input loaded into a variable called input
                var input = @"
                    <div class='person'>
                    {
                        'name':'Bob',
                        'age':20,
                        'color':'blue'
                    }
                    </ div >
                    < div class='person'>
                    {
                        'name':'John',
                        'age':30,
                        'color':'green'
                    }
                    </div>
                ".Replace("'", "\"");
    
                Regex jsonItems = new Regex("{[^}]+}");
                var persons = jsonItems.Matches(input).Select(x => JsonConvert.DeserializeObject<Person>(x.Groups[0].Value)).ToArray();
                var names = string.Join(",", persons.Select(x => x.name));
                Console.WriteLine($"names={names}");
            }
    
            class Person {
                public string name { get; set; }
                public int age { get; set; }
                public string color { get; set; }
            }
        }
    }
