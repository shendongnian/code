    public partial class MainWindow : Window
    {
        private Regex gramOrMilliGramRegex = new Regex("^[0-9.-]+(m?g)?$");
        public MainWindow ()
        {
            InitializeComponent();
        }
        private void txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(sender is TextBox txtbox)
            {
                string newString = txtbox.Text.Substring(0, txtbox.CaretIndex) + e.Text + txtbox.Text.Substring(txtbox.CaretIndex); //Build the new string
                e.Handled = !gramOrMilliGramRegex.IsMatch(e.Text); //Check if it matches the regex
            }
            
        }
        private void txtbox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if(sender is TextBox txtbox)
            {
                string newString = txtbox.Text.Substring(0, txtbox.CaretIndex) + e.DataObject.GetData(typeof(string)) as string + txtbox.Text.Substring(txtbox.CaretIndex); //Build new string
                if (!digitOnlyRegex.IsMatch(newString)) //Check if it matches the regex
                {
                    e.CancelCommand();
                }
            }
        private void txtbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Prevents whitespace
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }
    }
