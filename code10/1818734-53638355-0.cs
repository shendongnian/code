    public MainWindow()
        {
            InitializeComponent();
            StackPanelOfButtons stackPanelOfButtons = new StackPanelOfButtons(
                new List<myButton>{
                    new myButton(50, 100, "It Worked!"),
                    new myButton(100, 150, "We have more buttons"),
                    new myButton(150, 200, "And a third button")});
            this.Content = stackPanelOfButtons.stackPanel;
        }
