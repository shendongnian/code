    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1(bool minimized)
            {
                InitializeComponent();
                if (minimized)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
        }
    }
