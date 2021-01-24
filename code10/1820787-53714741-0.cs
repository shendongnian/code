    private void OPCode()
        {
            dataGridView1.Columns.Add("DateColumn", "Date");
            dataGridView1.Columns.Add("LemonColumn", "Lemon");
            dataGridView1.Columns.Add("TrefoilColumn", "Trefoils");
            dataGridView1.Columns.Add("DSDColumn", "Do-Si-Dos");
            dataGridView1.Columns.Add("SamoasColumn", "Samoas");
            dataGridView1.Columns.Add("TagsColumn", "Tagalongs");
            dataGridView1.Columns.Add("ThinMintsColumn", "Thin Mints");
    
            string[] alllines = File.ReadAllLines("Path to file");
            //Create an array to hold values for the row
            string[] row = new string[7];
            //loop through all the lines in the file but step by 7
            //because we will use the lines inbetween to populate each row
            for (int i = 0; i < alllines.Count(); i += 7)
            {
                for (int x = 0; x < 7; x++)
                {
                    row[x] = alllines[x + i];
                }
                dataGridView1.Rows.Add(row);
            }
        }
