    public string Label
    {
        get { return (string.IsNullOrEmpty(Text) ? Text : Text.Replace("\n", @"\n")); }
        set {
            Text = (string.IsNullOrEmpty(value) ? value : value.Replace(@"\n", "\n"));
        }
    }
