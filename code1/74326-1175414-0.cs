    private void DoSomething()
    {
        _settings.FixedBooks.Add("Test");
        _settings.Save();
        _settings.Reload();
    }
