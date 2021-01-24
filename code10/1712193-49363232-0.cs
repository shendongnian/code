        private void txtPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPerson.Text == "")
            {
                MessageBox.Show("Bitte geben ein gültige Personalnummer !!");
            }
            else if (e.KeyCode == Keys.Enter && txtPerson.Text != "")
            {
                dataGridView1.Enabled = true;
                dataGridView1.Focus();
                dataGridView1.Rows[0].Cells[1].Selected = true;
                e.SuppressKeyPress = true;
            }
        }
