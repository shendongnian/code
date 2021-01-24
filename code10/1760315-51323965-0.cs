    try
            {
                checkedListBox1.SelectedIndexChanged -= checkedListBox1_SelectedIndexChanged;
                if (checkedListBox1.Items.Count != 0)
                {
                    if (checkedListBox1.SelectedItem.ToString() == "Select all")
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                        string changed = "Deselect all";
                        checkedListBox1.Items[checkedListBox1.SelectedIndex] = changed;
                    }
                    else if (checkedListBox1.SelectedItem.ToString() == "Deselect all")
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, false);
                        }
                        string changed = "Select all";
                        checkedListBox1.Items[checkedListBox1.SelectedIndex] = changed;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            }
