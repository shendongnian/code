             DataGridViewColumn[] gridColumns = new DataGridViewColumn[dataGridView1.Columns.Count];
             dataGridView1.Columns.CopyTo(gridColumns, 0); //This created a list of columns
             gridColumns = (from n in gridColumns
                            orderby n.DisplayIndex descending
                            select n).ToArray(); //This then changed the order based on the displayindex
