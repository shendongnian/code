    static void Main(string[] args)
    {
        Console.WriteLine("Enter a text:");
        string text = Console.ReadLine();
        int count = 0;
        count = NumberOfCommas(text);
      
        Console.WriteLine("There's {0} comma(s) in your text.", count);
        Console.ReadKey();
    }
    int NumberOfCommas(String text1)
    {
		int count;
            foreach (char letter in text1)
            {
                if (letter == ',' )
                {
                    count++;
                }
            }
            return count;
    }
