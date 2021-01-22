    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (dataGridView1.IsCurrentCellInEditMode)
        {
            dataGridView1.Columns[0].Width += 5;    //index or name of your column
        }
    }
