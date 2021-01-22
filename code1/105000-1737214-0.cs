    namespace SomeNamespace
    {
        public partial class Form2 : Form
        {
           string someStr = string.Empty;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            public Form2(string params) // Parametrized Constructor
            {
                InitializeComponent();
    
                someStr  = params
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
              Form2TextBox.Text = someStr  ;
            }
        }
    }
