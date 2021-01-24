    private static void Main()
    {
        int[] myArray = new int[10];
        while (true)
        {
            int enteredNumber = ShowMenu();
            if (enteredNumber == 1)
            {
                PopulateArray(myArray);
            }
            else if (enteredNumber == 9)
            {
                if (Login(1234, 3))
                {
                    PrintArray(myArray);
                    WaitForUserInput();
                }
            }
        }
    }
