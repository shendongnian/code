    public async Task SomeAsyncMethod XViewModel(int UserID)
    {
        await GetUserInfo();
        EmployeListBox = new[]
        {
            new EmployeListBoxItems(PackIconKind.UndoVariant, "Listing", new YWindow( new YViewModel(Code_abc)) ),
        };
        Console.WriteLine("3");
    }
