    public partial class NewItemForm : Form
    {
        public NewItemForm()
        {
            InitializeComponent();
        }
        private void clearAllButton_Click(object sender, EventArgs e)
        {
            FormUtils.ClearAllTextBoxes(this);
        }
    }
