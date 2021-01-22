    using System;
    using System.Windows;
    using System.Windows.Interop;
    
    namespace WpfApplication1
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            protected override void OnSourceInitialized(EventArgs e)
            {
                base.OnSourceInitialized(e);
                HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
                source.AddHook(WndProc);
            }
    
            private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                // Handle messages...
    
                return IntPtr.Zero;
            }
        }
    }
