    // Our private list of menu items that will be displayed to the user
    private static List<MenuItem> MenuItems;
    // A helper method to populate our list. 
    // We can easily add or remove new items to the menu
    // without having to worry about changing an 
    // enum or adding a command to a switch block
    private static void PopulateMenuItems()
    {
        MenuItems = new List<MenuItem>
        {
            new MenuItem {Description = "View balance", Execute = ViewBalance},
            new MenuItem {Description = "Deposit", Execute = Deposit},
            new MenuItem {Description = "Withdraw", Execute = Withdraw},
        };
    }
