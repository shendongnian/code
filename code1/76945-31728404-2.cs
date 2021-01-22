    using System.Windows.Forms;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1(string foo):base()
            {
               //use foo here
            }
    
            public Form1()         //Visual studio designer likes this!
            {
                InitializeComponent();
            }
        }
    }
