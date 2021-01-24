    static void Main()
    {
        Console.Write("Enter a word or phrase : ");
        string input = Console.ReadLine()/*"cheesecake"*/;
        char[] listOfVowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        int vowel = 0;
            
        vowel = input.Count(z => listOfVowels.Contains(z));
        var sameVowelPair = input.Where(c => listOfVowels.Contains(c)).GroupBy(c => c).ToDictionary(s1 => s1.Key, s1=> s1.Count()).OrderByDescending(w => w.Value).FirstOrDefault();
        Console.WriteLine($"The total number of vowel are : {vowel}");
        Console.WriteLine($"The total of the same number of vowel are : {sameVowelPair.Value}");
    }
