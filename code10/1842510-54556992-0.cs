    private void Button_Click(object sender, EventArgs e)
    {
      int count = 0;
      for (int row = 0; row < _dgv.Rows.Count; ++row)
      {
        if (row.Cells[_comboBoxColumnNumberOrName].Value == "Yes")
        {
          count++;
        }
      }
      textBox1.Text = $"{count}";
    }
