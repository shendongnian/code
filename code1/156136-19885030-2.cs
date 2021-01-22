    public partial class TestControl : UserControl
        {
            //Declare routed commands
            public static RoutedCommand IncrementCommand;
            public static RoutedCommand DecrementCommand;
    
            static TestControl()
            {
                //Create routed commands and add key gestures.
                IncrementCommand = new RoutedCommand();
                DecrementCommand = new RoutedCommand();
                IncrementCommand.InputGestures.Add(new KeyGesture(Key.Add, ModifierKeys.Control));
                DecrementCommand.InputGestures.Add(new KeyGesture(Key.Subtract, ModifierKeys.Control));
            }
    
            public TestControl()
            {
                //Subscribe to Increment/Decrement events.
                TestControl.Decremented += down;
                TestControl.Incremented += up;
    
                InitializeComponent();
            }
            
            //Declare *static* Increment/Decrement events.
            public static event EventHandler Incremented;
            public static event EventHandler Decremented;
    
            //Raises Increment event
            public static void IncrementMin(object o, ExecutedRoutedEventArgs args)
            {
                if (Incremented != null)
                {
                    Incremented(o, args);
                }
            }
    
            //Raises Decrement event
            public static void DecrementMin(object o, ExecutedRoutedEventArgs args)
            {
                if (Decremented != null)
                {
                    Decremented(o, args);
                }
            }
    
            //Handler for static increment
            private void down(object o, EventArgs args)
            {
                Min--;
            }
    
            //Handler for static decrement
            private void up(object o, EventArgs args)
            {
                Min++;
            }
    
            //Backing property
            public int Min
            {
                get { return (int)GetValue(MinProperty); }
                set { SetValue(MinProperty, value); }
            }
    
            public static readonly DependencyProperty MinProperty =
                DependencyProperty.Register("Min", typeof(int),
                typeof(TestControl), new UIPropertyMetadata(0));
        }
