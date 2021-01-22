        private void MyGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                DataGridViewRow currentRow = MyGrid.CurrentRow;
                MessageBox.Show( Convert.ToString(currentRow.Cells[0].Value));
            }
        }
