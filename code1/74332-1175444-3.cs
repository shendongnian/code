    private void DoSomething()
    {
        _settings.FixedBooks.Add("Test");
        lbFixedColumns.DataSource = null;
        _settings.FirePropertyChanged("FixedBooks");
    }
 
