    public partial class FormA : Window
    {
        NotifyComboBoxChange notifyDel;
        public FormA(NotifyComboBoxChange notify)
        {
            InitializeComponent();
            notifyDel = notify;
        }
        private void cmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // This gets the currently selected value in the CombBox
            var value = cmbItems.SelectedValue.ToString();
            // This invokes the delegate, which in turn calls the ComboBoxValueChanged() method in Main.
            notifyDel?.Invoke(value);
        }
    }
