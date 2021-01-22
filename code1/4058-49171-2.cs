        public WindowMain()
        {
           InitializeComponent();
           // Bind Key
           InputBinding ib = new InputBinding(
               MyAppCommands.SaveAll,
               new KeyGesture(Key.S, ModifierKeys.Shift | ModifierKeys.Control));
           this.InputBindings.Add(ib);
           // Bind handler
           CommandBinding cb = new CommandBinding( MyAppCommands.SaveAll);
           cb.Executed += new ExecutedRoutedEventHandler( HandlerThatSavesEverthing );
           this.CommandBindings.Add (cb );
        }
        private void HandlerThatSavesEverthing (object obSender, ExecutedRoutedEventArgs e)
        {
          // Do the Save All thing here.
        }
