    //DataGridView dgv = ...
    dgv.Rows.Clear();
    string file="c:\\mygrid.bin";
    using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
    {
       int n=bw.ReadInt32();
       int m=bw.ReadInt32();
       for(int i=0;i<m;++i)
       {
             dgv.Rows.Add();
             for (int j = 0; j < n; ++j)
             {
                   if (bw.ReadBoolean())
                   {                                        
                         dgv.Rows[i].Cells[j].Value = bw.ReadString();                                        
                   }
                   else bw.ReadBoolean();
              }
         }
    } 
