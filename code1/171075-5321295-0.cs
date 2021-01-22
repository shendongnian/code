    //Code to insert dummy records...            
    for (int i = 0; i < 10; i++)
    {
         dataGridView1.Rows.Add(
         "COl1-" + i.ToString(),
         "COl2-" + i.ToString(),
         "COl3-" + i.ToString(),
         "COl4-" + i.ToString(),
         "COl5-" + i.ToString()
         );
    }
                
    
    //Set the Background color to cell
    bool isBackColorSet = false;
    foreach (DataGridViewRow r in dataGridView1.Rows)
    {
         foreach (DataGridViewCell c in r.Cells)
         {
              if (!isBackColorSet)
              {
                  c.Style.BackColor = Color.Red;
              }
              isBackColorSet = !isBackColorSet;
         }
    }
