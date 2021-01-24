        enum MenuSelection
        {
            Create_Customer = 1,
            Create_Account = 2,
            Set_Account_Balance = 3,
            Display_Account_Balance = 4,
            Exit = 5,
            MaxMenuSelection = 5,
        }
        public static void Menu()
        {
            for (int i = 1; i <= (int)MenuSelection.MaxMenuSelection; i++)
            {
                Console.WriteLine($"[{i}] {((MenuSelection)i).ToString().Replace("_"," ")}");
            }
        }
