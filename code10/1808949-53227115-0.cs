    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
		Form2 f2 = new Form2(id);
		f2.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
		f2.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
		f2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
		f2.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
		f2.Show();
		this.Hide();
    }
