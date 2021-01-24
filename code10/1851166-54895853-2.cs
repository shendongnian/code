    for (int i = 0; i < SIZE; i++)
    {
       string input = Console.ReadLine();
       double num = 0;
       while(!Double.TryParse(input, out num))
       {
           Console.WriteLine("Not valid, please enter numbers only");
           input = Console.ReadLine();
       }
        array[i] = num;
    }
