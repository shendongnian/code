    private void button1_Click(object sender, EventArgs e)
    {
        this.textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        string[] items = GetListForCustomSource();
        this.textBox1.AutoCompleteCustomSource.AddRange(items);
       
    }
    private string[] GetListForCustomSource()
    {
        var result = new List<string>();
        foreach(var value in Enum.GetNames(typeof(DayOfWeek)))
        {
            result.Add(value);
        }
        return result.ToArray();
    }
