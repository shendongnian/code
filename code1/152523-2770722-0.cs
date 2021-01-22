    void SaveDTtoCSV(DataTable dt)
    {
        // Save data to CSV file 
        StreamWriter writer = new StreamWriter(@"c:/dsoutput.csv");
        // First we will write the headers.
        int iColCount = dt.Columns.Count;
        for(int i = 0; i < iColCount; i++)
        {
            writer.Write(dt.Columns[i]);
            if (i < iColCount - 1)
            {
                writer.Write(",");
            }
        }
        writer.Write(writer.NewLine);
        // Now write all the rows.
        foreach (DataRow dr in dt.Rows)
        {
            for (int i = 0; i < iColCount; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    writer.Write(dr[i].ToString());
                }
                if ( i < iColCount - 1)
                {
                    writer.Write(",");
                }
            }
            writer.Write(writer.NewLine);
        }
        writer.Close();
    }
