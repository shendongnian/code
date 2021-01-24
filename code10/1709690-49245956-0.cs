    private void ColorDates()
    {
        if (dataGridView1.Rows.Count <= 0)
        {
            MessageBox.Show("Datagridview is empty!");
            return;
        }
        foreach(DataGridViewRow row in dataGridView1.Rows)
        {
            DateTime value = Convert.ToDateTime(row.Cells["DateColumn"].Value);
            DateTime citeria = new DateTime(2018, 28, 02);
            int result = DateTime.Compare(value, citeria);
            if (result < 0) //value is earlier than citeria
                ColorRow(row, Color.Red);
            else if (result == 0) //Value is equal to citeria
                ColorRow(row, Color.Green);
            else if (result > 0) //value is later than citeria
                ColorRow(row, Color.Blue);
        }
    }
    private void ColorRow(DataGridViewRow row, Color color)
    {
        foreach(DataGridViewCell cell in row.Cells)
        {
            cell.Style.BackColor = color;
        }
    }
