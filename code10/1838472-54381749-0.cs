    public void view()
    {
             try
            {
                     textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch(Exception ex)
            {
                     MessageBox.Show(ex.Message);
            }
    }
