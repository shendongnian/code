    try
     {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = "Excel Documents (*.xls)|*.xls";
      saveFileDialog1.FileName = "Employee Details.xls";
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
      string fname = saveFileDialog1.FileName;
      StreamWriter wr = new StreamWriter(fname);
      for (int i = 0; i <DataTable.Columns.Count; i++)
      {
      wr.Write(DataTable.Columns[i].ToString().ToUpper() + "\t");
      }
      wr.WriteLine();
    
      //write rows to excel file
      for (int i = 0; i < (DataTable.Rows.Count); i++)
      {
      for (int j = 0; j < DataTable.Columns.Count; j++)
      {
      if (DataTable.Rows[i][j] != null)
      {
      wr.Write(Convert.ToString(getallData.Rows[i][j]) + "\t");
      }
       else
       {
       wr.Write("\t");
       }
       }
       //go to next line
       wr.WriteLine();
       }
       //close file
       wr.Close();
       }
       }
       catch (Exception)
       {
        MessageBox.Show("Error Create Excel Sheet!");
       }
