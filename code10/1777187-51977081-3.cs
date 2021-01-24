    private void SaveCustomPreset_Click(object sender, EventArgs e)
    {
        var columns = new [] 
        {
            CustomPresetName.Text, 
            CustomX.Text, 
            CustomY.Text, 
            CustomZ.Text, 
            Foam.Text
        };
    
        var line = string.Join(",", columns);
        using (TextWriter txt = new StreamWriter("../../PresetData.csv", true))
        {
            txt.WriteLine(line);
        }
    
        var dt = (DataTable)PresetView.DataSource;
        foreach(var item in columns)
        {
            dt.Rows.Add(item)
        }
    }
