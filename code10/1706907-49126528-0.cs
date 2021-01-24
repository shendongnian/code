    void readSandwichSelection()
    {
        int[] ToppingArray = new int[toppingsAvailable.SelectedItems.Count];
        for (int i = 0; i < toppingsAvailable.SelectedItems.Count; i++)
        {
            var selectedIndex = toppingsAvailable.Items.IndexOf(toppingsAvailable.SelectedItems[i]);
            ToppingArray[i] = selectedIndex;
        }
    }
