    using System.Drawing; 
    using System.Linq; 
    using System.Text; 
    using System.Windows.Forms; 
     
    namespace WinApp_WMI2 
    { 
        public partial class Form1 : Form 
        { 
            CERas.CERAS m_CERAS;
    
            public Form1() 
            { 
                InitializeComponent(); 
            } 
     
        private void Form1_Load(object sender, EventArgs e) 
        { 
            m_CERAS = new CERas.CERAS(); 
        } 
    } 
     
     
    }
