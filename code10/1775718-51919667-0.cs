    public static Timer Pause_ForCreate(Label _ChangeImageEllipse)
    {
      Timer _T = new Timer(2000);
      _T.Elapsed += (sender, e) => _ChangeImageEllipse.Visibility = true; // or false? Not sure what you want to set it to.
      _T.AutoReset = false;
      _T.Start();
      return _T
    }
