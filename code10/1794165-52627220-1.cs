    int sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count;++i)
    {
        if(int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString()))
        {
            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
        }
                
    
    }
    
    label1.Text = sum.ToString();
