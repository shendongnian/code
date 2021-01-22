    Button ParametersButton = new Button();
    ParametersButton.Click += delegate
        {
            ParameterForm pf = new ParameterForm(testString);
            pf.ShowDialog(this); // Blocks until user submits
            // Do whatever pf_Submit did here.
        };
    public partial class ParameterForm : Form
    {
        public string test;
        public XmlElement node;
        public delegate void ParameterSubmitResult(object sender, XmlElement e);
        public event ParameterSubmitResult Submit;
        public void SubmitButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(test);
            this.Close(); // Returns from ShowDialog()
        }
     }
