    private void selectSpecs(DataTable table)
            {
                while (checkedListBox1.CheckedIndices.Count > 0)
                {
                    checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
                }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                DataRow r;
                r = ((DataRowView)this.checkedListBox1.Items[i]).Row;
                string val = (r[this.checkedListBox1.ValueMember]).ToString();
                channelsSpecs.Add(Convert.ToInt32(val));
                r = null;
                for (int j = 0; j < table.Rows.Count; j++)
                    foreach (DataRow dataRow in table.Rows)
                        foreach (var item in dataRow.ItemArray) if (val.ToString() == item.ToString()) checkedListBox1.SetItemChecked(i, true);
            }
        }
