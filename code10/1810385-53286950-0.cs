    static int numberRequest(string prompt, int left, int top)
    {
        int num;
        // Loop until user enters valid input
        while (true) {
            Console.SetCursorPosition(left, top);
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out num)) {
                return num;
            }
        }
    }
