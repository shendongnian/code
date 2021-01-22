    public partial class Window1 : Window
    {
        private uint m_previousExecutionState;
    
        public Window1()
        {
            InitializeComponent();
    
            // Set new state to prevent system sleep (note: still allows screen saver)
            m_previousExecutionState = NativeMethods.SetThreadExecutionState(
                NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            if (0 == m_previousExecutionState)
            {
                MessageBox.Show("Call to SetThreadExecutionState failed unexpectedly.",
                    Title, MessageBoxButton.OK, MessageBoxImage.Error);
                // No way to recover; fail gracefully
                Close();
            }
        }
    
        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
    
            // Restore previous state
            if (0 == NativeMethods.SetThreadExecutionState(m_previousExecutionState))
            {
                // No way to recover; already exiting
            }
        }
    }
    
    internal static class NativeMethods
    {
        // Import SetThreadExecutionState Win32 API and necessary flags
        [DllImport("kernel32.dll")]
        public static extern uint SetThreadExecutionState(uint esFlags);
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
    }
