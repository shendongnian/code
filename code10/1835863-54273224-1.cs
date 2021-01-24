    static void Main(string[] args)
        WriteInstructions();
        CaptureUserInput();
    }
    public static void WriteInstructions() {
        // instruct the user for each available operation
        Console.WriteLine("1: Addition");
        Console.WriteLine("2: Subtraction");
    }
    public static void CaptureUserInput() {
        Console.WriteLine("Enter a number between 1 and 6 to perform a calculation");
        // capture the user's input and convert it to an integer
        string stringInput = Console.Readline();
        int input = int.Parse(stringInput);
        // validate that it is a valid integer
        if (Enumerable.Range(1,6).Contains(input)) {
            // this is a valid number in the range we want, call the Work method
            Work(input);
        } else {
            // the user has entered an invalid entry, prompt them and wait for another attempt
            Console.WriteLine("Sorry, that is an invalid option.");
            CaptureUserInput();
        }
    }
