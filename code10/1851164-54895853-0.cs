    for (int i = 0; i < SIZE; i++)
    {
       string line = Console.ReadLine();
       double val =0;
       while(!Double.TryParse(line, out val))
       {
           Console.WriteLine("Invalid Input try again.");
           line = Console.ReadLine();
       }
        array[i] = Double.Parse(val);
    }
