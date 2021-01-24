    private List<Preset> GetAll()
    {
        var list = new List<Preset>();
        using (var db = new LiteDatabase(DB))
        {
            var col = db.GetCollection<Preset>("presets");
            foreach (Preset _id in col.FindAll())
            {
                list.Add(_id);
            }
        }
        return list;
    }
    public void DisplayPresetData()
    {
        PresetView.DataSource = GetAll();
    }
