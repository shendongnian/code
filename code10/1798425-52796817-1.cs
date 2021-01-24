    while (entered_number != 0)
    {
        //ask for user entry
        Console.Write("enter a number: ");
        entered_number = int.Parse(Console.ReadLine());
        if (entered_number < 0)
        {
            Console.WriteLine("Number is negative");
        }
        else 
        {
            //variable for subprogram
            bool prime = IsPrimeNumber(entered_number);
            //output
            if (prime == true)
            {
                Console.WriteLine("Number is Prime");
            }
            else if (prime == false)
            {
                Console.WriteLine("Number is not Prime");
            }
        }
    }
    Console.WriteLine("End of program");
    Console.ReadKey();
