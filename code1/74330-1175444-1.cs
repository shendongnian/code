    private void DoSomething()
    {
        _settings.FixedBooks.Add("Test");    
        var old = _settings.FixedBooks;
        _settings["FixedBooks"] = new List<string>();
        _settings["FixedBooks"] = old;
    }
