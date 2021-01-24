    string[] myStrings = new string[] { "Cat", "Dog", "Horse", "CaT", "cat", "DOG" };
    CountTerms(myStrings, "cat", "dog");
    Console.ReadKey();
    static void CountTerms(string[] strings, params string[] terms) {
        
        foreach (string term in terms) {
            int result = 0;
            foreach (string s in strings)
                if (s == term)
                    result++;
            Console.WriteLine($"There are {result} instances of {term}");
        }
    }
