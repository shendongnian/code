    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RegisterEvents();
        }
    
        private void RegisterEvents()
        {
            _tboTest.TextChanged += new EventHandler(TboTest_TextChanged);
        }
    
        private void TboTest_TextChanged(object sender, EventArgs e)
        {
            // Change the text to bold on specified condition
            if (_tboTest.Text.Equals("Bold", StringComparison.OrdinalIgnoreCase))
            {
                _tboTest.Font = new Font(_tboTest.Font, FontStyle.Bold);
            }
            else
            {
                _tboTest.Font = new Font(_tboTest.Font, FontStyle.Regular);
            }
        }
    }
