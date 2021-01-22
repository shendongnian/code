    //DataGridView dgv=...
    string file= "c:\\mygrid.bin";
    using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
    {
        bw.Write(dgv.Columns.Count);
        bw.Write(dgv.Rows.Count);
        foreach (DataGridViewRow dgvR in dgv.Rows)
        {
           for (int j = 0; j < dgv.Columns.Count; ++j)
           {
               object val=dgvR.Cells[j].Value;
               if (val == null)
               {
                    bw.Write(false);
                    bw.Write(false);
                }
                else
                {
                    bw.Write(true);
                    bw.Write(val.ToString());
                 }
             }
        }
