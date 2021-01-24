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
                    InputHandler.numUpDown1 = numUpDown1;
                    InputHandler.mainForm.Controls["button1"].Click += InputHandler.OnButton1Click;
                    InputHandler.mainForm.Controls["button2"].Click += InputHandler.OnButton2Click;
                    InputHandler.mainForm.Controls["numUpDown1"].Click += InputHandler.OnNumUpDown1Changed;
                }
            }
        }
