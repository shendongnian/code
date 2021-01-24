    static (int, char, int) vowelStats(string str)
    {
      // VOWEL ONLY DICTIONARY
      Dictionary<char, int> counts = new Dictionary<char, int>()
      {
        {'a', 0} , { 'e', 0} , { 'i', 0} , { 'o', 0} , { 'u', 0} 
      };
      int vowels = 0;
      char high = '0';
      int sub = 0;
      foreach(char c in str)
      {
        char c1 = Char.ToLower(c); // convert letter to lowercase first
        // if dictionary has the character, then it must be a vowel
        if (counts.ContainsKey(c1))
        {
          counts[c1]++; // vowel itself count
          vowels++;     // total vowels count
          if(vowels - counts[c1] <= sub) // update most frequent vowel
          {
            sub = vowels - counts[c1];
            high = c1;
          }
        }
      }
      return (vowels, high, counts[high]);
      
    }
    static void Main(string[] args)
    {
      Console.Write("Enter a word or phrase : ");
      string input = Console.ReadLine();
      int vowels, mostFrequentVowelCount;
      char mostFrequenctVowel;
      (vowels, mostFrequenctVowel, mostFrequentVowelCount) = vowelStats(input);
      Console.WriteLine("Total number of vowels: {0}", vowels);
      Console.WriteLine("Most frequent vowel: {0}", mostFrequenctVowel);
      Console.WriteLine("Most frequent vowel count: {0}", mostFrequentVowelCount);
    }
