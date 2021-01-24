    static void Main(string[] args)
    {
        while (true)
        {
            // This is loop constantly occurs.
            //variables;
            string UserInput;
            int count = 0;
            //Where I ask for user inout then convert to text file.
            Console.WriteLine("Enter a text file into the console.");
            UserInput = Console.ReadLine();
            char LastCharacter = UserInput[UserInput.Length - 1];
            
            // 1) You need to extract the words in the user input - this assumes they are delimited by a space
            foreach (var word in UserInput.Split(' '))
            {
                // 2) You want to check the first character of each word 
                // 3) The StringComparison.CurrentCultureIgnoreCase assumes you want to ignore case - if you DO want to consider case, remove the parm
                // 4) You can do the compare using the 'or' operator - no need for else if
                if (word.StartsWith("t", StringComparison.CurrentCultureIgnoreCase) || word.StartsWith("e", StringComparison.CurrentCultureIgnoreCase))
                {
                    count++;
                }
            }
            Console.WriteLine("There are  {0}", +count + "  words that end in t or e.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
