    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Validation validation = new Validation();
            if(validation.validate(ref txtName, MyExpander) && validation.validate(ref txtAge, MyExpander)) // Pass the Expander object
            {
                //Do Something.
            }
        }
    }
    public class Validation
    {
        public bool validate(ref TextBox txtobj, Expander expander)
        {
            if (string.IsNullOrWhiteSpace(txtobj.Text))
            {
                MessageBox.Show("Please Enter Data..!");
                expander.IsExpanded = true; // Add this
                txtobj.Focus();
                return false;
            }
            return true;
        }   
    }
