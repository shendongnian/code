    int sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count;++i)
    {
        int temp = 0;
        int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out temp);
        sum += temp;
        
    }
    
    label1.Text = sum.ToString();
