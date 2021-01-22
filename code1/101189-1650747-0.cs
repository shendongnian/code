    private void txtConsole_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyData == (Keys.C | Keys.Control))
        {
            _consolePort.Write(new byte[] { 3 }, 0, 1);
            e.Handled = true;
        }
    }
