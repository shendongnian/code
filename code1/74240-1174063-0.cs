    public class CalculationResultForm : Form
    {
        public CalculationResultForm(){}
    
        public decimal Counter
        {
            set { labelCounter.Text = value.ToString(); }
        }
        public decimal Broad
        {
            set { labelBroad.Text = value.ToString(); }
        }
        public decimal Narrow
        {
            set { labelNarrow.Text = value.ToString(); }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            // This will close the form (same as clicking ok on the message box)
            DialogResult = DialogResult.OK;
        }
    }
