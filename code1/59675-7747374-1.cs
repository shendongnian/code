    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr GetOpenClipboardWindow();
    
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern int GetWindowText(int hwnd, StringBuilder text, int count);
    
    private void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox1.Text);
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg += Environment.NewLine;
            msg += Environment.NewLine;
            msg += "The problem:";
            msg += Environment.NewLine;
            msg += getOpenClipboardWindowText();
            MessageBox.Show(msg);
        }
    }
    
    private string getOpenClipboardWindowText()
    {
        IntPtr hwnd = GetOpenClipboardWindow();
        StringBuilder sb = new StringBuilder(501);
        GetWindowText(hwnd.ToInt32(), sb, 500);
        return sb.ToString();
        // example:
        // skype_plugin_core_proxy_window: 02490E80
    }
