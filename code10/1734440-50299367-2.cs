    public void RunCommand()
    {
        ConsoleOutput.Add(new YourType { Text = ConsoleInput, Foreground = Brushes.Orange } );
        ConsoleInput = String.Empty;
    }
