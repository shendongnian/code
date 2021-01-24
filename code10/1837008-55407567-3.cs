    public CustomPickerCell()
    {
        InitializeComponent();
    
        ItemPicker.ItemsSource = this.ItemsSource;
        ItemPicker.SelectedItem = this.SelectedItem;
    
        ItemPicker.SelectedIndexChanged += OnSelectedIndexChanged;
    }
    
    /// <summary>
    /// Calle when ItemPicker's SelectedIndexChanged event fires.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedItem = (ItemPicker.SelectedIndex < 0 || ItemPicker.SelectedIndex > ItemPicker.Items.Count - 1) ? null : ItemsSource[ItemPicker.SelectedIndex];
    }
