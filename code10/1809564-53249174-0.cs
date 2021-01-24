        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Closed += OnClosed;
            }
            private void OnClosed(object sender, EventArgs e)
            {
                // DO, what you need when windows closed
            }
        }
