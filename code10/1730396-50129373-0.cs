    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                string str = (string)e.Value;
                str = char.ToUpper(str[0]) + str.Substring(1);
                e.Value = str;
            }
        }
