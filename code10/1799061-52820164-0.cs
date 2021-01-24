    List<int> Attemptsnums= new List<int>();   
 
    for (int i = 0; i < 100000; i++)
    {
    z++; 
    Console.Write("\nGuess the number I imagined: ");
    int c = Convert.ToInt32(Console.ReadLine()); // all of numbers that I type should appear.
    if (b == c)
    {
        Console.WriteLine("\n Congratulations you guessed in {0} attempts. :)",z); // this is just showing how many attempts I had.
        Attemptsnums.Add(c); // here I've put c but It only shows last number I entered, I need all of them in line.
        foreach (var element in Attemptsnums)
        {
            Console.WriteLine("Numbers: {0}", element);
        }
        break;
     }
    }
