    // These are initially populated from the last row of the table when the program loads
    private int LastEntryNumber;
    private int LastEntryMonth;
    // Sample code enclosed in a method body
    private void AddEntry()
    {
        // Update the last month if needed (as well as the last entry number)
        if (DateTime.Today.Month != LastEntryMonth)
        {
            LastEntryMonth = DateTime.Today.Month;
            LastEntryNumber = 0;
        }
        // Increment our number
        LastEntryNumber = LastEntryNumber + 1;
        textbox1.Text = LastEntryNumber + "/" + LastEntryMonth;
    }
