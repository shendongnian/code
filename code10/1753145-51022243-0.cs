    public ObservableCollection<string> Items { get; set; }
    private void Button_Clicked(object sender, EventArgs e)
    {
        if(Items == null) 
        {
            Items = new ObservableCollection<string>
            {
                TxtEntry.Text
            };
        } 
        else {
            Items.Add(TxtEntry.Text);
        }
        MyListView.ItemsSource = Items;
    }
