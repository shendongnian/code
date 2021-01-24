    _timer.Tick += async (s, e) =>
    {
        _flag = false;
        _timer.Stop();
        try
        {
            await Presenter.Search(); // Call async DB calls
        }
        catch (Exception ex) // Cannot capture the Exception of `Presenter.Search()`
        {
            MessageLabel.Text = "Error:....";
        }
    };
