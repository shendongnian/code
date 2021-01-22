    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Runtime.InteropServices;
    
    namespace WpfApplication1
    {
      /// <summary>
      /// Interaction logic for Window1.xaml
      /// </summary>
      public partial class Window1 : Window
      {
        public Window1()
        {
          InitializeComponent();
        }
    
        const int WS_EX_NOACTIVATE = 0x08000000;
        const int GWL_EXSTYLE = -20;
    
        [DllImport("user32", SetLastError = true)]
        private extern static int GetWindowLong(IntPtr hwnd, int nIndex);
    
        [DllImport("user32", SetLastError = true)]
        private extern static int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewValue);
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          WindowInteropHelper wih = new WindowInteropHelper(this);
          int exstyle = GetWindowLong(wih.Handle, GWL_EXSTYLE);
          exstyle |= WS_EX_NOACTIVATE;
          SetWindowLong(wih.Handle, GWL_EXSTYLE, exstyle);
        }    
      }
    }
