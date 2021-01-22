    public MainWindow()
    {
        InitializeComponent();
        //Raise control's static events in response to routed commands
        this.CommandBindings.Add(
            new CommandBinding(TestControl.IncrementCommand, new ExecutedRoutedEventHandler(TestControl.IncrementMin)));
        this.CommandBindings.Add(
            new CommandBinding(TestControl.DecrementCommand, new ExecutedRoutedEventHandler(TestControl.DecrementMin)));            
    }
