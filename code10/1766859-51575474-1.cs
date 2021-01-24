    static bool FeatureIsOn { get; set;}
    static void Main()
    {
        bool optionIsValid;
        do //Loops around until the option is valid
        {
            Console.WriteLine();
            Console.Write("Enable Feature? [Y/N]: ");
            string optionString =  Console.ReadLine();
            // convert string to uppercase 
            optionString = optionString.ToUpper();
 
            switch(optionString)
            {
                case "YES":
                case "Y":
                    FeatureIsOn = true;
                    optionIsValid = true;
                break;
                case "NO":
                case "N":
                    FeatureIsOn = false;
                    optionIsValid = true;
                break;
                default:
                    Console.WriteLine("Invalid option.");
                    optionIsValid = false;
                break;
            }
        } while (optionIsValid != true);
    }
