    [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, " +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        typeof(UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ComboBox.ObjectCollection ComboItems {
        get { return comboBox1.Items; }
    }
