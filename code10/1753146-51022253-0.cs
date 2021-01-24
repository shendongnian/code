    public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();
    public YourConstructor()
    {
       MyListView.ItemsSource = Items;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Items.Add(TxtEntry.Text);
    }
