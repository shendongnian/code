    public Window1()
        {
            InitializeComponent();
            ApplicationCommands.Find.InputGestures.Add(new KeyGesture(Key.Space, ModifierKeys.Control));
            CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Find, myCommandHandler);
            this.CommandBindings.Add(commandBinding);
        }
        private void myCommandHandler(object sender, ExecutedRoutedEventArgs args)
        {
            MessageBox.Show("Command invoked!");
        }
