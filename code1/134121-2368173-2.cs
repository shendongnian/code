    static void Main(string[] args)
    {
            bool validInput = false;
            string inputString;
            UInt32 validPositiveInteger = 0;
            while (!validInput)
            {
                Console.WriteLine("Please enter a positive 32 bit integer:");
                inputString = Console.ReadLine();
                if (!UInt32.TryParse(inputString, out validPositiveInteger))
                {
                    Console.WriteLine("Input was not a positive integer.");
                }
                else if (validPositiveInteger.Equals(0))
                {
                    Console.WriteLine("You cannot enter zero.");
                }
                else
                {                   
                    validInput = true;
                    //Or you could just break
                    //break;
                }
                
            }
            Console.WriteLine(String.Format("Positive integer = {0}", validPositiveInteger));
    }
