    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Loaded += OnLoaded;
            this.KeyDown += OnKeyDown;
            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            SendKeys.Send(Key.A);
            SendKeys.Send(Key.B);
            SendKeys.Send(Key.C);
            SendKeys.Send(Key.D);
            SendKeys.Send(Key.LeftCtrl);
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Key pressed: " + e.Key);
        }
    }
    public static class SendKeys
    {
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) { RoutedEvent = Keyboard.PreviewKeyDownEvent };
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }
