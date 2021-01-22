     public partial class TestControl : UserControl
        {
            static TestControl()
            {
                IncrementCommand = new RoutedCommand();
                DecrementCommand = new RoutedCommand();
                IncrementCommand.InputGestures.Add(new KeyGesture(Key.Add, ModifierKeys.Control));
                DecrementCommand.InputGestures.Add(new KeyGesture(Key.Subtract, ModifierKeys.Control));
            }
    
            public TestControl()
            {
                TestControl.Decremented += down;
                TestControl.Incremented += up;
    
                InitializeComponent();
            }
    
            public int Min
            {
                get { return (int)GetValue(MinProperty); }
                set { SetValue(MinProperty, value); }
            }
    
            public static readonly DependencyProperty MinProperty =
                DependencyProperty.Register("Min", typeof(int),
                typeof(TestControl), new UIPropertyMetadata(0));
    
    
            private void down(object o, EventArgs args)
            {
                Min--;
            }
    
            private void up(object o, EventArgs args)
            {
                Min++;
            }
    
            public static RoutedCommand IncrementCommand;
            public static RoutedCommand DecrementCommand;
    
            public static event EventHandler Incremented;
            public static event EventHandler Decremented;
    
            public static void IncrementMin(object o, ExecutedRoutedEventArgs args)
            {
                if (Incremented != null)
                {
                    Incremented(o, args);
                }
            }
    
            public static void DecrementMin(object o, ExecutedRoutedEventArgs args)
            {
                if (Decremented != null)
                {
                    Decremented(o, args);
                }
            }
        }
