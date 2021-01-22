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
            // bind the Text property on the label to the AValue property on the object instance.
            this.ValueLabel.DataBindings.Add("Text", this.TheClass, "AValue");
            // bind the textbox to the same value...
            this.NewValueTextBox.DataBindings.Add("Text", this.TheClass, "AValue");
        }
        private void UpdateValueButton_Click(object sender, EventArgs e)
        {
            //// simulate a modification to the value of the class
            //this.TheClass.AValue = this.NewValueTextBox.Text;
        }
