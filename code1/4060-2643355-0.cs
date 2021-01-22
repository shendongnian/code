using System.Windows;
using System.Windows.Interop;
namespace WpfApp
{
    public partial class MainWindow : Window
    {
        const int WM_KEYUP = 0x0101;
        const int VK_RETURN = 0x0D;
        const int VK_LEFT = 0x25;  
      
        public MainWindow()
        {
            this.InitializeComponent();
            ComponentDispatcher.ThreadPreprocessMessage += 
                ComponentDispatcher_ThreadPreprocessMessage;
        }
        void ComponentDispatcher_ThreadPreprocessMessage(
            ref MSG msg, ref bool handled)
        {
            if (msg.message == WM_KEYUP)
            {
                if ((int)msg.wParam == VK_RETURN)
                    MessageBox.Show("RETURN was pressed");
                
                if ((int)msg.wParam == VK_LEFT)
                    MessageBox.Show("LEFT was pressed");
            }
        }
    }
}
