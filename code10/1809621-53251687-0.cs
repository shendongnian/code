    // Destiny form
    public partial class FormDestiny : Form {
        // Property for receive data from other forms, you decide the datatype
        public string ExternalData { get; set; }
        public FormDestiny() {
            InitializeComponent();
            // Set external data after InitializeComponent()
            this.MyLabel.Text = ExternalData;
        }
    }
    // Source form. Here, prepare all data to send to destiny form
    public partial class FormSource : Form {
        public FormSource() {
            InitializeComponent();
        }
        private void SenderButton_Click(object sender, EventArgs e) {
            // Instance of destiny form
            FormDestiny destinyForm = new FormDestiny();
            destinyForm.ExternalData = PrepareExternalData("someValueIfNeeded");
            destinyForm.ShowDialog();
        }
        // Your business logic here
        private string PrepareExternalData(string myparameters) {
            string result = "";
            // Some beautiful and complex code...
            return result;
        }
    }
