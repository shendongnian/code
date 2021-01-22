    public static void PopulateComboBox<T>(ComboBox box, ResourceManager res) {
        box.FormattingEnabled = true;
        ListControlConvertEventHandler del = delegate(object sender, ListControlConvertEventArgs e) {
            e.Value = res.GetString(e.Value.ToString());
        };
        box.Format -= del;
        box.Format += del;
        box.BeginUpdate();
        box.Items.Clear();
        foreach(T value in Enum.GetValues(typeof(T))) {
            box.Items.Add(value);
        }
        box.EndUpdate();
    }
