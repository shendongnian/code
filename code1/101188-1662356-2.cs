    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.When(Keys.F).With(Keys.Control).IsDown().Do((sender, e) => MessageBox.Show(e.KeyData.ToString()));
        }
    }
