    public class SomeObject
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
            
            private static void ListCount()
            {
                var items = new List<SomeObject>
                {
                    new SomeObject {FirstName = "santa", LastName = "claus"},
                    new SomeObject {FirstName = "fred", LastName = "claus"},
                    new SomeObject {FirstName = "tooth", LastName = "fairy"},
                    new SomeObject {FirstName = "easter", LastName = "bunny"},
                };
    
                var byLastNameFrequency = items.GroupBy(i => i.LastName).OrderByDescending(g => g.Count()).ThenBy(g => g.Key);
                foreach (var name in byLastNameFrequency)
                {
                    Console.WriteLine(name.Key + ", " + name.Count());
                }
            }
