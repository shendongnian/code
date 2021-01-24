    foreach (DataGridViewRow sr in dataGridView1.SelectedRows)
    {
        if(i >= 10)
        {
            strs.Add(str.ToList()); //Here strs have one str with 10 values
            str.Clear();
            i = 0;
            var a = strs; //Here strs have one str with 0 values
        }
        str.Add(sr.Cells["MOBILNI"].Value.ToString().Trim());
        i++;
    }
    strs.Add(str);
