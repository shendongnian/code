    public string DataPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserData.xml");
    public CellModel Current
    {
        get => (CellModel)cellModelBindingSource.Current;
    }
    protected override void OnLoad(EventArgs e)
    {
        if(File.Exists(DataPath))
        {
            var xml = File.ReadAllText(DataPath);
            var sample = SampleData.FromXml(xml);
            this.cellModelBindingSource.DataSource = sample.Cells;
            MessageBox.Show($"Data read from {DataPath}");
        }            
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var data = this.cellModelBindingSource.DataSource as DataModel[]
        var sample = new SampleData(data);
        File.WriteAllText(this.DataPath, sample.ToXml());
        MessageBox.Show($"Data written to {DataPath}");
    }
