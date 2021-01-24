    using System.Windows.Forms;
    
    namespace InputFormTest
    {
        public partial class mainForm : Form
        {
            public mainForm()
            {
                InitializeComponent();
                InitializeInputs();
            }
    
            void InitializeInputs()
            {
                InputHandler.mainForm = this;
                InputHandler.debugBox = debugBox;
                InputHandler.mainForm.Controls["button1"].Click += InputHandler.OnButton1Click;
                InputHandler.mainForm.Controls["button2"].Click += InputHandler.OnButton2Click;
                ((NumericUpDown)InputHandler.mainForm.Controls["numUpDown1"]).ValueChanged += InputHandler.OnNumUpDown1Changed;
            }
        }
    }
