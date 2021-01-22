    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace LinqExamples
    {
        // https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
        class Program
        {
            static void Main(string[] args)
            {
                loadData();
                // Print all the subjects
                Console.WriteLine("------------------(SelectMany) Print all the subjects--------------------");
                Console.WriteLine(string.Join("\n", students.SelectMany(s => s.subjects).Distinct()));
    
                // Sort by first subject and then by first name
                Console.WriteLine("\n------------------(OrderBy ThenBy) Sort by first subject and then by first name--------------------");
                Console.WriteLine(string.Join("\n", students.OrderBy(x => x.subjects[0]).ThenBy(m => m.FirstName)));
    
                Console.WriteLine("\n------------------Group by first subject and then no of student oppted for the subject--------------------");
                Console.WriteLine(string.Join("\n", students.GroupBy(x => x.subjects[0]).Select(s => new { Subject = s.Key, count = s.Count() })));
                foreach (var g in students.GroupBy(x => x.subjects[0]).Select(s => new { Subject = s.Key, count = s.Count(), studentFirstName = s.Select(x => x.FirstName) }))
                {
                    Console.WriteLine("Subject: {0}, Total Student: {1}, Student FirstNames: {2}", g.Subject, g.count, string.Join(", ", g.studentFirstName));
                }
                
                string wordsString = "This is the same book which all the student used to read";
                Console.WriteLine(string.Join("\n", wordsString.Split(' ').GroupBy(x => x).Select(s => new { Word = s.Key, count = s.Count() })));
    
                Console.WriteLine("\n------------------(OrderByDescending) Top 2 Salary--------------------");
                Console.WriteLine(string.Join("\n", students.OrderByDescending(s => s.Salary).Take(2)));
    
                Console.WriteLine("\n------------------Distinct--------------------");
                int[] arr = { 2, 2, 3, 5, 5 };
                Console.WriteLine($"[{string.Join(", ", arr)}]");
                Console.WriteLine(string.Join(", ", arr.Distinct()));
    
                Console.WriteLine("\n------------------(Union) Unique numbers from both arrays--------------------");
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };
                Console.WriteLine($"[{string.Join(", ", numbersA)}]");
                Console.WriteLine($"[{string.Join(", ", numbersB)}]");
                Console.WriteLine(string.Join(", ", numbersA.Union(numbersB).OrderBy(x => x)));
    
                Console.WriteLine("\n------------------(Intersect) Common numbers shared by both arrays--------------------");
                Console.WriteLine($"[{string.Join(", ", numbersA)}]");
                Console.WriteLine($"[{string.Join(", ", numbersB)}]");
                Console.WriteLine(string.Join(", ", numbersA.Intersect(numbersB).OrderBy(x => x)));
    
                Console.WriteLine("\n------------------(Except) Numbers in first array but not second array--------------------");
                Console.WriteLine($"[{string.Join(", ", numbersA)}]");
                Console.WriteLine($"[{string.Join(", ", numbersB)}]");
                Console.WriteLine(string.Join(", ", numbersA.Except(numbersB).OrderBy(x => x)));
    
                Console.WriteLine("\n------------------Concat numbers from both arrays--------------------");
                Console.WriteLine($"[{string.Join(", ", numbersA)}]");
                Console.WriteLine($"[{string.Join(", ", numbersB)}]");
                Console.WriteLine(string.Join(", ", numbersA.Concat(numbersB).OrderBy(x => x)));
    
                Console.WriteLine("\n------------------ToDictionary--------------------");
                var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                    new {Name = "Bob"  , Score = 40},
                                    new {Name = "Cathy", Score = 45}
                                };
                var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);
                Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
    
                Console.WriteLine("\n------------------OfType--------------------");
                object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0, true };
                Console.WriteLine($"[{string.Join(", ", numbers)}]");
                var doubles = numbers.OfType<double>();
                Console.WriteLine("Numbers stored as doubles: " + string.Join(", ", numbers.OfType<double>()));
                Console.WriteLine("Numbers stored as bool: " + string.Join(", ", numbers.OfType<bool>()));
                Console.WriteLine("Numbers stored as string: " + string.Join(", ", numbers.OfType<string>()));
                Console.WriteLine("Numbers stored as int: " + string.Join(", ", numbers.OfType<int>()));
    
                Console.WriteLine("\n------------------First with Condition--------------------");
                string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Console.WriteLine($"[{string.Join(", ", strings)}]");
                Console.WriteLine("A string starting with 'o': {0}", strings.FirstOrDefault(s => s[0] == 'o'));
    
                Console.WriteLine("\n------------------GroupBy with Condition--------------------");
                int[] num = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Console.WriteLine($"[{string.Join(", ", num)}]");
                var numberGroups = num.GroupBy(x => x % 5).Select(g => new { Remainder = g.Key, Numbers = g });
                foreach (var g in numberGroups)
                {
                    Console.WriteLine("Numbers with a remainder of {0} when divided by 5: {1}", g.Remainder, string.Join(", ", g.Numbers));
                }
    
                Console.WriteLine("\n------------------Range--------------------");
                Console.WriteLine(string.Join(", ", Enumerable.Range(1, 5)));
    
                Console.WriteLine($"\n{string.Join("", Enumerable.Repeat('-', 18))}Repeat{string.Join("", Enumerable.Repeat('-', 18))}");
                Console.WriteLine("Repeat(Print) '*' for 5 times: " + string.Join("", Enumerable.Repeat('*', 5)));
    
                Console.WriteLine("\n------------------Any--------------------");
                string[] words = { "believe", "relief", "receipt", "field" };
                Console.WriteLine($"[{string.Join(", ", words)}]");
                Console.WriteLine("Is there any word which contains 'ei': {0}", words.Any(w => w.Contains("ei")));
                Console.WriteLine("Is there any word which start with 'f': {0}", words.Any(w => w[0] == 'f'));
                Console.WriteLine("Is there any word which start with 'n': {0}", words.Any(w => w[0] == 'n'));
    
                Console.WriteLine("\n------------------All--------------------");
                int[] nos = { 1, 11, 3, 19, 41, 65, 19 };
                Console.WriteLine($"[{string.Join(", ", nos)}]");
                Console.WriteLine("The list contains only odd numbers: {0}", nos.All(n => n % 2 == 1));
                Console.WriteLine("The list contains only even numbers: {0}", nos.All(n => n % 2 == 0));
    
    
                Console.WriteLine("\n------------------Where with index --------------------");
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Console.WriteLine($"[{string.Join(", ", digits)}]");
    
                var shortDigits = digits.Where((digit, index) => digit.Length < index);
                Console.WriteLine(string.Join(" is shorter in length than its index position\n", shortDigits));
    
                Console.WriteLine("\n------------------Select with index --------------------");
                Console.WriteLine($"[{string.Join(", ", digits)}]");
                foreach (var n in digits.Select((x, indexi) => new { word = x, InPlace = indexi }))
                {
                    Console.WriteLine("{0}: {1}", n.word, n.InPlace);
                }
    
                Console.WriteLine("\n------------------SequenceEqual (all array element matches in the same order)--------------------");
                var wordsA = new string[] { "cherry", "apple", "blueberry" };
                var wordsB = new string[] { "cherry", "apple", "blueberry" };
                Console.WriteLine($"[{string.Join(", ", wordsA)}]");
                Console.WriteLine($"[{string.Join(", ", wordsB)}]");
                Console.WriteLine("The sequences match: {0}", wordsA.SequenceEqual(wordsB));
            }
    
            private static void loadData()
            {
                students.Add(new Student("English", "Math"));
                students.Add(new Student("Physics", "Math"));
                students.Add(new Student("Chemistry", "Math"));
                students.Add(new Student("English", "Hindi"));
                students.Add(new Student("GK", "Science"));
                students.Add(new Student("English", "Math"));
                students.Add(new Student("Physics", "Math"));
                students.Add(new Student("Chemistry", "Math"));
                students.Add(new Student("English", "Hindi"));
                students.Add(new Student("GK", "Science"));
            }
    
            public static List<Student> students = new List<Student>();
        }
    
        public class Student
        {
            public string FirstName { get; set; } = Faker.Name.First();
            public string LastName { get; set; } = Faker.Name.Last();
            public string Mobile { get; set; } = Faker.Phone.Number();
            public int Salary { get; set; } = Faker.RandomNumber.Next(1000, 10000);
            public Guid Id { get; set; } = Guid.NewGuid();
            public List<string> subjects = new List<string>();
            public Student(params string[] subjects)
            {
                foreach (var sub in subjects)
                {
                    this.subjects.Add(sub);
                }
            }
    
            public override string ToString()
            {
                return $"{this.FirstName} {this.LastName} {this.Salary}\t{this.subjects[0]}, {this.subjects[1]} {this.Mobile}";
            }
        }
    }
