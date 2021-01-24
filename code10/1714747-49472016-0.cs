        public static double[] inputArray = new double[40];
        public static string input;
        public static int idx = 0;
        static void Main(string[] args)
        {
            GetInput();
            Console.Read();
        }
        public static void GetInput()
        {
            Console.Write("enter a number to add to the array or 'continue' to display the array: ");
            input = Console.ReadLine();
            while (!CheckInput(input))
            {
                Console.Write("enter a number to add to the array or 'continue' to display the array: ");
                input = Console.ReadLine();
            }
        }
        public static bool CheckInput(string _input)
        {
            bool Continue = false;
            if (input == "continue")
            {
                PrintArray();
                Continue = true;
            }
            else
            {
                inputArray[idx] = double.Parse(_input);
                idx++;
                Continue = false;
            }
            return Continue;
        }
        public static void PrintArray()
        {
            for(int i = 0; i < inputArray.Length - 1; i++)
            {
                Console.WriteLine(inputArray[i]);
            }
        }
    }
