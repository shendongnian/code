        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, checkedListBox1.GetItemCheckState(0));
                }
            }
            else //if you unchecked one of the other checkbox when select all is checked, then the select all is unchecked 
            {
                if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                {
                    checkedListBox1.SetItemCheckState(0, CheckState.Unchecked);
                }
            }
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            List<string> filtered= cboxAr.AsEnumerable()
                .Where(x => x.ToUpper().Contains(SearchBox.Text.ToUpper()))
                .ToList();
            checkedListBox1.DataSource = filtered;
            if (String.IsNullOrWhiteSpace(SearchBox.Text))
            {
                checkedListBox1.DataSource = cboxAr;
            }
        }
