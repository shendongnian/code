    Button ParametersButton = new Button();
    ParametersButton.Click += delegate
        {
            ParameterForm pf = new ParameterForm(testString);
            pf.ShowDialog(this); // Blocks until user submits
            // Do whatever pf_Submit did here.
        };
    public partial class ParameterForm : Form
    {
        public string test;     // Generally, encapsulate these
        public XmlElement node; // in properties
        public void SubmitButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(test);
            this.Close(); // Returns from ShowDialog()
        }
     }
