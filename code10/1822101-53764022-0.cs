    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (checkedListBox1.GetItemChecked(0))
                {
                    SelectDeselectAll(true);
                }
                else
                {
                    SelectDeselectAll(false);
                } 
            }
    
            private void SearchBox_TextChanged(object sender, EventArgs e)
            {
                string filter_param = SearchBox.Text.ToUpper();
                var item = checkedListBox1.Items.Cast<string>().ToList();
                List<string> filteredItems = item.FindAll(x => x.ToUpper().Contains(filter_param));
    
                checkedListBox1.DataSource = filteredItems;
    
                // if all values removed, bind the original full list again
                if (String.IsNullOrWhiteSpace(SearchBox.Text))
                {
                    checkedListBox1.DataSource = dt;
                }
            }
    
            private void SelectDeselectAll(bool toSelect)
            {
                if (toSelect)
                {
                    for (int i = 1; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
                else
                {
                    checkedListBox1.ClearSelected();
                }
            }
