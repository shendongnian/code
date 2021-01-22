    namespace csWinFormsTest
    {
        public partial class Form1 : Form
        {
            static System.IO.Ports.SerialPort thePort;
            public Form1()
            {
                InitializeComponent();
                thePort = new System.IO.Ports.SerialPort("COM1");
            }
    
            static void fcn()
            {
                MessageBox.Show(thePort.PortName);
            }
        }
    }
