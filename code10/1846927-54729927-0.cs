    static (int, char, int) vowelStats(string str)
    {
      // VOWEL ONLY DICTIONARY
      Dictionary<char, int> counts = new Dictionary<char, int>()
      {
        {'a', 0} , { 'e', 0} , { 'i', 0} , { 'o', 0} , { 'u', 0} , { 'A', 0} , { 'E', 0} , { 'I', 0} , { 'O', 0} , { 'U', 0 }
      };
      int vowels = 0;
      char high = '0';
      int sub = 0;
      foreach(char c in str)
      {
        // if dictionary has the character, then it must be a vowel
        if (counts.ContainsKey(c))
        {
          counts[c]++; // for the vowel itself
          vowels++;    // total number of vowels
          
          if(vowels - counts[c] <= sub) // used to keep record of most frequent vowel
          {
            // update the most frequent vowel information
            sub = vowels - counts[c]; 
            high = c;
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
