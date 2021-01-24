    private void DisplayPresetData(string filePath)
    {
        DataTable dt = new DataTable();
        string[] csv_data = System.IO.File.ReadAllLines(filePath);
        string[] data_col = null;
        int x = 0;
        foreach (string text_line in csv_data)
        {
            data_col = text_line.Split(',');
            if(x == 0)
            {
                for(int i = 0; i <= data_col.Count() -1; i++)
                {
                    dt.Columns.Add(data_col[i]);
                }
                x++;
            }
            else
            {
                dt.Rows.Add(data_col);
            }
        }
        PresetView.DataSource = dt;
    }
