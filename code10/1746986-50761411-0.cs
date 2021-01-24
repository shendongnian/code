    Entry _newEntry = new Entry();
    private void AddEntry_Clicked(object sender, EventArgs e)
    {
        SplitterEntries.Children.Add(_newEntry);
    }
    private void OtherMethod()
    {
        string currentValue = _newEntry.Text;
    }
