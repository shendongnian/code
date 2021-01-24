        public static void Main()
    {
        UserOption userSelection;
        List myList = new List();
        do
        {
            userSelection = ReadUserOption();
            switch (userSelection)
            {
                case UserOption.NewValue:
                    myList.NewValue();
                    break;
                case UserOption.Sum:
                    myList.Sum();
                    break;
                case UserOption.Print:
                    myList.Print();
                    break;
                case UserOption.Quit:
                    Console.WriteLine("Quit");
                    break;
            }
        }
        while (userSelection != UserOption.Quit);
    }
