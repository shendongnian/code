    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows;
    
    
    namespace WpfSender
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var process = Process.GetProcessesByName("WpfListener").FirstOrDefault();
                if (process == null)
                {
                    MessageBox.Show("Listener not running");
                }
                else
                {
                    SendMessage(process.MainWindowHandle, RF_TESTMESSAGE, IntPtr.Zero, IntPtr.Zero);
                }
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
            private const int RF_TESTMESSAGE = 0xA123;
        }
    }
