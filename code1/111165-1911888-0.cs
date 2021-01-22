    public MyCommandBar()
    {
      _myBar = App.CommandBars.Add("My Toolbar", 1, Type.Missing, true);
      // Add a button to call our custom event handler
      _printSetup = (CommandBarButton)
              _myBar.Controls.Add(MsoControlType.msoControlButton, 
              Type.Missing, Type.Missing, 1, true); 
      _printSetup.Click += printSetup_Click(); // Call the handler shown in my original question
      // More stuff...
    }
