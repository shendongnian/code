    public string[] ComboItems {
        get {
            return comboBox1.Items.Cast<object>()
                    .Select(x => x.ToString()).ToArray();
        }
        set {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(value);
        }
    }
