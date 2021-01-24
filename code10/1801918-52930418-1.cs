    static void Main(string[] args) {
      List<string> namesList = new List<string>();
      for (int i = 0; i < 5; i++)  {
        namesList.Add(Console.ReadLine());
        Console.WriteLine($"In the word {namesList[i]} is {CountVowels(namesList[i])} vowels");
      }
      ...
    }
