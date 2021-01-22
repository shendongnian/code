    #region "---------Update Diag Window Text------------------------------------"
    // This sub allows the diag window to be updated by all threads
    public void updateDiagWindow(string whatmessage)
    {
        var _with1 = diagwindow;
        if (_with1.InvokeRequired) {
            _with1.Invoke(new UpdateDiagDelegate(UpdateDiag), whatmessage);
        } else {
            UpdateDiag(whatmessage);
        }
    }
    // This next line makes the private UpdateDiagWindow available to all threads
    private delegate void UpdateDiagDelegate(string whatmessage);
    private void UpdateDiag(string whatmessage)
    {
        var _with2 = diagwindow;
        _with2.appendtext(whatmessage);
        _with2.SelectionStart = _with2.Text.Length;
        _with2.ScrollToCaret();
    }
    #endregion
