    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
    
        string intro6 = "How many characters in the password? (USE INTEGERS)";
        foreach (char c in intro6)
        {
            Console.Write(c);
            Thread.Sleep(50);
        }
        Console.WriteLine("");
        string delta = Console.ReadLine();
    
        try
        {
            int passwordlength = Convert.ToInt32(delta);
    
            // BARRIER
    
            string password = RandomString(passwordlength);
    
            Random r = new Random();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            List<string> dictionary = new List<string>(new string[] { password });
    
            string word = dictionary[r.Next(dictionary.Count)];
            List<int> indexes = new List<int>();
            Console.ForegroundColor = ConsoleColor.Red;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(letters[r.Next(letters.Length)]);
                if (sb[i] != word[i])
                {
                    indexes.Add(i);
    
                }
            }
            Console.WriteLine(sb.ToString());
    
            var charsToGuessByIndex = indexes.ToDictionary(k => k, v => letters);
    
            while (indexes.Count > 0)
            {
                int index;
    
                Thread.Sleep(10);
                Console.Clear();
    
                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    index = indexes[i];
    
                    var charsToGuess = charsToGuessByIndex[index];
                    sb[index] = charsToGuess[r.Next(charsToGuess.Length)];
                    charsToGuessByIndex[index] = charsToGuess.Remove(charsToGuess.IndexOf(sb[index]), 1);
                    if (sb[index] == word[index])
                    {
                        indexes.RemoveAt(i);
                    }
                }
                var output = sb.ToString();
    
                for (int i = 0; i < output.Length; i++)
                {
                    if (indexes.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
    
                    Console.Write(output[i]);
                }
    
                Console.WriteLine();
            }
    
            Console.ForegroundColor = ConsoleColor.Green;
    
            string outro1 = "Password successfully breached. Have a nice day.";
            foreach (char c in outro1)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine("");
            Thread.Sleep(100);
    
            Console.ReadLine();
        }
        catch
        {
            if (delta is string)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("FATAL ERROR PRESS ENTER TO EXIT");
    
    
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("welp, it was worth a try.");
                Console.ReadLine();
            }
        }
    }
