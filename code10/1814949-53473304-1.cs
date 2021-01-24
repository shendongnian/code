    public partial class InvoiceForm : Form
    {
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searcher = new SearchForm();
            searcher.Show(this);
        }
        public void UpdateControls(string Code, string Name, string Blah)
        {
            this.CodeTextBox.Text = Code;
            this.NameTextBox.Text = Name;
            this.BlahTextBox.Text = Blah;
        }
    }
    public partial class SearchForm : Form
    {
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string CodeValue = sqldr[codecolumn].ToString()
                string NameValue = sqldr[Namecolumn].Tostring
                string BlahValue = sqldr[Blahcolumn].Tostring 
                if (this.Owner is InvoiceForm frm)
                {
                    frm.UpdateControls(CodeValue, NameValue, BlahValue);
                    this.Close();
                }
            }
        }
    }
