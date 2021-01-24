        var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        Console.WriteLine("Write something : ");
        var input = Console.ReadLine().ToLower();
        int total = 0;
        for (int temp = 1; temp <= input.Length; temp++)
        {
            if (vowels.Contains(input[temp - 1]))
            {
                total += temp;
            }
         }
         Console.WriteLine("The length is " + total * input.Length);
