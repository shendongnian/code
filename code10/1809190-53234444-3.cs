    static void MainMenu()
    {
        ClearAndShowHeading("Main Menu");
        // Write out the menu options
        for (int i = 0; i < MenuItems.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {MenuItems[i].Description}");
        }
        // Get the cursor position for later use 
        // (to clear the line if they enter invalid input)
        int cursorTop = Console.CursorTop + 1;
        int userInput;
        // Get the user input
        do
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write($"Enter a choice (1 - {MenuItems.Count}): ");
        } while (!int.TryParse(Console.ReadLine(), out userInput) ||
                    userInput < 1 || userInput > MenuItems.Count);
        // Execute the menu item function
        MenuItems[userInput - 1].Execute();
    }
