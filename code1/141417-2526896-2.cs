        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
            InitializeCommands();
        }
        
        private static RoutedCommand _myCommand;
        public static RoutedCommand MyCommand
        {
            get
            {
                return _myCommand;
            }
        }
        private static void InitializeCommands()
        {
            _myCommand = new RoutedCommand("MyCommand", typeof(MyCustomControl));
            CommandManager.RegisterClassCommandBinding(typeof(MyCustomControl),
                                    new CommandBinding(_myCommand , OnMyCommandExecute));
        }
        private static void OnMyCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            MyCustomControl control = sender as MyCustomControl;
            if (control != null)
            {
                //logic for this command
            }
        }
        
