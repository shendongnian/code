    static void Main()
    {
        Console.Write("Enter a word or phrase : ");
        string input = Console.ReadLine();
        char[] listOfVowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        int vowel = 0;
        int sameVowel = 0;
        vowel = input.Count(x => listOfVowels.Contains(x));
       sameVowel = input.Where(c => listOfVowels.Contains(c)).GroupBy(c => c).ToDictionary(g => g.Key, g.Value.Count()).OrderByDescending().Take(1);
        Console.WriteLine($"The total number of vowel are : {vowel}");
        Console.WriteLine($"The total of the same number of vowel are : {sameVowel}");
    }
