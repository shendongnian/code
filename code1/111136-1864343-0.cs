        private void myDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            myDataGridView1.EndEdit();
            if (myDataGridView1.CurrentCell.Value != null)
            {
                textBox1.Text = myDataGridView1.CurrentCell.Value.ToString();
                textBox2.Text = myDataGridView1.CurrentCell.FormattedValue.ToString();
            }
            myDataGridView1.BeginEdit(false);
        }
