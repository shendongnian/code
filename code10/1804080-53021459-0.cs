            string searchValue = searchtextBox.Text.ToLower(); //simple search Full row from text box with button
             dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            try //try to run the following code
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //i++
                   
                    for (int i = 0; i < row.Cells.Count; i++)//for loop to enable iteration throught the gridview rows
                    {
                      
                        //if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                       
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().ToLower().Contains(searchValue))
                        {
                            int rowIndex = row.Index;
                            dataGridView1.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            searchResults.Text += "=> " + row.Cells[i].Value + " " + Environment.NewLine.Trim();//outputs search results to multi line textbox separated by commas and trimmed white space of   
                           
                        }
                        
                      
                    }
                   
                }
