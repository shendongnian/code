      try
      {
        DataTable dtExcel = new DataTable();
        dtExcel = ReadExcel(filePath, fileExt); //read excel file  
        HashSet<string> addedItems = new HashSet<string>();
        dataGridView1.DataSource = dtExcel;
        mydatagrid.Rows.Clear();
        for (int i = 1; i < dataGridView1.Rows.Count; i++)
        {
          if (!addedItems.Contains(dataGridView1.Rows[i].Cells[0].Value.ToString()))
          {
            mydatagrid.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
            addedItems.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
          }
        }
      }
