        private void button1_Click(object sender, EventArgs e)
        {
            // you can Set the combo box value using this;
            list[0].ReportCodeLookup = 1; // depend on combo box cell value
            dataGridView1.Invalidate();
        }
