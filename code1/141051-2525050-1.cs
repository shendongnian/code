    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MyClass TheClass;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TheClass = new MyClass();
            this.ValueLabel.DataBindings.Add("Text", this.TheClass, "AValue");
        }
        private void UpdateValueButton_Click(object sender, EventArgs e)
        {
            // simulate a modification to the value of the class
            this.TheClass.AValue = this.NewValueTextBox.Text;
        }
    }
