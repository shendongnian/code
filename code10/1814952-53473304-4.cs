    public partial class InvoiceForm : Form
    {
        public class UpdateMyControls 
        {
            public string CodeText { get; set; }
            public string NameText { get; set; }
            public string BlahText { get; set; }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searcher = new SearchForm();
            searcher.Show(this);
        }
        public void UpdateControls(UpdateMyControls allValues)
        {
            this.CodeTextBox.Text = allValues.CodeText;
            this.NameTextBox.Text = allValues.NameText;
            this.BlahTextBox.Text = allValues.BlahText;
        }
    }
    public partial class SearchForm : Form
    {
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Owner is InvoiceForm frm)
                {
                    InvoiceForm.UpdateMyControls updateClass = new InvoiceForm.UpdateMyControls();
                    updateClass.CodeText = sqldr[codecolumn].ToString();
                    updateClass.NameText = sqldr[Namecolumn].ToString();
                    updateClass.BlahText = sqldr[Blahcolumn].ToString();
                    frm.UpdateControls(updateClass);
                    this.Close();
                }
            }
        }
    }
