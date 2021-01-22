        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
            InitializeCommands();
        }
        public static RoutedCommand IncreaseCommand
        {
            get
            {
                return _increaseCommand;
            }
        }
        public static RoutedCommand DecreaseCommand
        {
            get
            {
                return _decreaseCommand;
            }
        }
        private static void InitializeCommands()
        {
            _increaseCommand = new RoutedCommand("IncreaseCommand", typeof(MyCustomControl));
            CommandManager.RegisterClassCommandBinding(typeof(MyCustomControl),
                                    new CommandBinding(_increaseCommand, OnIncreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(MyCustomControl),
                                    new InputBinding(_increaseCommand, new KeyGesture(Key.Up)));
            _decreaseCommand = new RoutedCommand("DecreaseCommand", typeof(MyCustomControl));
            CommandManager.RegisterClassCommandBinding(typeof(MyCustomControl),
                                    new CommandBinding(_decreaseCommand, OnDecreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(MyCustomControl),
                                    new InputBinding(_decreaseCommand, new KeyGesture(Key.Down)));
        }
        private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MyCustomControl control = sender as MyCustomControl;
            if (control != null)
            {
                control.OnIncrease();
            }
        }
        private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MyCustomControl control = sender as MyCustomControl;
            if (control != null)
            {
                control.OnDecrease();
            }
        }
        protected virtual void OnIncrease()
        {
            Value++;
        }
        protected virtual void OnDecrease()
        {
            Value--;
        }
        private static RoutedCommand _increaseCommand;
        private static RoutedCommand _decreaseCommand;
