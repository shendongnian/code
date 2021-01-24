      try
      {
        DataTable dtExcel = new DataTable();
        dtExcel = ReadExcel(filePath, fileExt); //read excel file  
        dataGridView1.DataSource = dtExcel;
        mydatagrid.Rows.Clear();
        for (int i = 1; i < dataGridView1.Rows.Count; i++)
        {
          bool exists = false;
          if (mydatagrid.Rows.Count == 1)
          {
            mydatagrid.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
          }
          else
          {
            for (int b = 1; b < (mydatagrid.Rows.Count - 1); b++)
            {
              //MessageBox.Show(mydatagrid.Rows[b].Cells[0].Value.ToString());
              if (dataGridView1.Rows[i].Cells[0].Value.ToString() == mydatagrid.Rows[b].Cells[0].Value.ToString())
              {
                exists = true;
                break;
              }
            }
            if (!exists)
            {
              mydatagrid.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
          }
        }
      }
