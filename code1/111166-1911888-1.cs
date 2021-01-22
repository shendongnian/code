    public MyCommandBar()
    {
      _myBar = App.CommandBars.Add("My Toolbar", 1, Type.Missing, true);
      // Call the built-in File Print Setup dialog automagically
      _printSetup = (CommandBarButton)
              _myBar.Controls.Add(MsoControlType.msoControlButton, 
              511, Type.Missing, 1, true); 
      // More stuff...
    }
