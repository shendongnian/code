        Dictionary<int, int> numberDictionary = new Dictionary<int, int>();
        string input;
        int number = 0;
        bool over = false;
        while (!over)
        {
            input = Console.ReadLine();
            if (input == "quit")
            {
                over = true;
                break;
            }
            if (int.TryParse(input, out number))
            {
                if (numberDictionary.ContainsKey(number))
                {
                    numberDictionary[number]++;
                }
                else
                {
                    numberDictionary.Add(number, 1);
                } 
            }
        }
        foreach(var item in numberDictionary)
        {
            if (item.Value == 1)
            Console.WriteLine(item.Key);
        }
        Console.ReadKey();
