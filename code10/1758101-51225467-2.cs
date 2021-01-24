    // Remove previous one.
    if (_currentPanel != null) {
        Controls.Remove(_currentPanel);
    }
    // Add new one
    _currentPanel = new MyNewPanel();
     //TODO: possibly set the panels Docking property to Fill here.
    Controls.Add(_currentPanel);
