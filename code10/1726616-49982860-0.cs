        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ActiveColumn = e.ColumnIndex;
            SearchTerm = string.Empty;
        }
        private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(SearchTerm))
            {
                Lookup(SearchTerm.ToLowerInvariant());
                SearchTerm = string.Empty;
            }
            else if (e.KeyCode == Keys.Back && SearchTerm.Length > 0)
            {
                SearchTerm = SearchTerm.Substring(0, SearchTerm.Length - 1);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SearchTerm = string.Empty;
            }
            else
            {
                var converter = new KeysConverter();
                var c = Convert.ToChar(converter.ConvertToString(e.KeyData));
                if (char.IsLetterOrDigit(c))
                {
                    SearchTerm += c;
                    label1.Text = SearchTerm;
                }
            }
        }
        private void Lookup(string what)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var currentText = row.Cells[ActiveColumn].Value.ToString().ToLowerInvariant();
                if (currentText.Contains(what))
                {
                    row.Selected = true;
                    break;
                }
            }
        }
