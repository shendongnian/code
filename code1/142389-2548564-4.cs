    static LooklessControl()
    {
        CommandManager.RegisterClassCommandBinding(
            typeof(LooklessControl),
            new CommandBinding(NextItemCommand, ExecutedNextItemCommand, CanExecuteNextItemCommand));
        CommandManager.RegisterClassCommandBinding(
            typeof(LooklessControl),
            new CommandBinding(PrevItemCommand, ExecutedPrevItemCommand, CanExecutePrevItemCommand));
    }
