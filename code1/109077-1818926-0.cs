    for (int i = 0; i < dgUsers.Columns.Count ;i++ )
          {
              for (int j = 0; j < dgUsers.Rows.Count; j++)
              {
                   dgUsers.Rows[j].Cells[i].Value = "";
              }
          }
