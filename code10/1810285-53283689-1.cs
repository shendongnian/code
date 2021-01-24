        string output = string.Empty;
        List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
        int counter = 0;
        foreach (int value in myList)
        {
    
            output += value.ToString();
            counter++;
            if (counter % 3 == 0)
            {
                Console.WriteLine(output);
                output = string.Empty;
            }
        }
