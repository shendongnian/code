    int vkey;
    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        vkey = System.Windows.Input.KeyInterop.VirtualKeyFromKey(e.Key);
        System.Windows.MessageBox.Show("Key char : " + e.Key);
    }
    {
        keybd_event((byte)vkey, 0x5B, 0, 0);
    }
