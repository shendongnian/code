    Int64 lookup = 1;
    do
    {
        Console.Write("Enter a zip code to look for: ");
        Console.WriteLine();
        Console.WriteLine("You may also enter 0 at any time to exit the program ");
        lookup = Convert.ToInt64(Console.ReadLine());
        int success = -1;
        for (int j = 0; j < zipCodes.Length; j++)
        {
            if (lookup == zipCodes[j])
            {
                success = j;
            }
        }
        if (success == -1) // our loop changes the  -1 if found in the directory
        {
            Console.WriteLine("No, that number is not in the directory.");
        }
        else
        {
            Console.WriteLine("Yes, that number is at location {0}.", success);
        }
    } 
    while (lookup != 0);
        
