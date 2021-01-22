    var vowels = new List<string> { "a", "e", "i", "o", "u" };
    var query = words.Select(s => new
                {
                    Text = s,
                    Count = s.Count(c => vowels.Exists(vowel => 
                        vowel.Equals(c.ToString(), 
                            StringComparison.InvariantCultureIgnoreCase)))
                });
    foreach (var item in query)
    {
    	Console.WriteLine("String {0} contains {1} vowels", item.Text, item.Count);
    }
