        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == 0 && e.Value != null) {
                long value = 0;
                if (long.TryParse(e.Value.ToString(), out value)) {
                    e.Value = "0x" + value.ToString("X");
                    e.FormattingApplied = true;
                }
            }
        }
