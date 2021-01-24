    Decimal sumcol = 0;
    for (int i = 0; i < dataGridView1.Rows.Count;++i)
    {
    Decimal val;
    string colval = dataGridView1.Rows[i].Cells[2].Value.ToString();
    if(colval  != null){
     if (Decimal.TryParse(colval, out val))
        sum += val;
    }
    label1.Text = sum.ToString();}
   
