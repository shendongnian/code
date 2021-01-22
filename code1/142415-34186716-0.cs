    namespace WinApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public void AccessConfig()
            {
                Engine.Properties.Settings.Default.EngineSetting = "test";
            }
        }
    }
