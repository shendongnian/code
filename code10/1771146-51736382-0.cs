    public delegate void NotifyComboBoxChange(string item);
    public partial class Form1 : Window
    {
        public NotifyComboBoxChange notifyDelegate;
        FormA formA = null;
        public Form1()
        {
            InitializeComponent();
            // This is 'registering' the ComboBoxValueChanged method to the delegate.
            // So, when the delegate is invoked (called), this method gets executed.
            notifyDelegate += new NotifyComboBoxChange(ComboBoxValueChanged);
        }
        public void ComboBoxValueChanged(string value)
        {
            txtLabel.Text = value;
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {            
            // Passing the delegate to `FormA`
            formA = new FormA(notifyDelegate);
            formA.Show();
        }
    }
