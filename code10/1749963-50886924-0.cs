You can use ObjectCollection for your property and asign it directly to your combobox. This way you are allowed to use the design editor.
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ObjectCollection ComboItems
    {
        get
        {
            return comboBox1.Items;
        }
        set
        {
            comboBox1.Items.Clear();
            foreach (var i in value)
                comboBox1.Items.Add(i);
        }
    }
