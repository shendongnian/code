    private void Numclient_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key < Key.D0 || e.Key > Key.D9)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
            {
                if (e.Key != Key.Back && e.Key != Key.Shift)
                {
                    e.Handled = true;
                }
            }
        }
    }
