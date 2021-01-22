    bool keepGoing = true;
    while (keepGoing)
    {
        switch (answer)
        {
            case "yes":
                Console.WriteLine("===============================================");
                Console.WriteLine("please enter the array index you wish to get the value of it");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("===============================================");
                Console.WriteLine("The Value of the selected index is:");
                Console.WriteLine(array[index]);
                keepGoing = false;
                break;
            case "no":
                Console.WriteLine("===============================================");
                Console.WriteLine("HAVE A NICE DAY SIR");
                keepGoing = false;
                break;
            default:
                Console.WriteLine("Sorry, I didn't understand that. Please enter yes or no");
                break;
        }
    }
