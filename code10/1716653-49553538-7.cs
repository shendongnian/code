    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            private bool mHasScrolledWithSystemKeyDown = false;
            private bool mSystemKeyIsDown = false;
            private IInputElement mLastFocusedControl;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                // If the system key is down...
                if (e.Key == Key.System)
                    // Track it
                    mSystemKeyIsDown = true;
            }
            private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
            {
                // If the system key is down while scrolling...
                if (mSystemKeyIsDown)
                {
                    // If it is the first scroll since it being down...
                    if (!mHasScrolledWithSystemKeyDown)
                        // Remember currently focused item
                        mLastFocusedControl = Keyboard.FocusedElement;
                    // And flag as scrolled with system key down
                    mHasScrolledWithSystemKeyDown = true;
                    // Prevent scroll...
                    e.Handled = true;
                    // TODO: Zoom
                }
            }
            private void Window_KeyUp(object sender, KeyEventArgs e)
            {
                // On system key up...
                if (e.Key == Key.System)
                {
                    // Track it
                    mSystemKeyIsDown = false;
                    // If we had scrolled with the system key down...
                    if (mHasScrolledWithSystemKeyDown)
                        // Cause a small delay to allow this key up to process
                        Task.Delay(0).ContinueWith((t) => Dispatcher.Invoke(() =>
                        {
                            // Then focus the last control to "close" the system menu gracefully
                            mLastFocusedControl?.Focus();
                        }));
                    // Flag the has scrolled to false to start again
                    mHasScrolledWithSystemKeyDown = false;
                }
            }
        }
    }
