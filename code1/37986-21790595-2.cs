    [DllImport("user32.dll")]
    static extern bool HideCaret(IntPtr hWnd);
    
    private void textBox2_Enter(object sender, EventArgs e)
    {
        // Kick off SelectAll asyncronously so that it occurs after Click
        BeginInvoke((Action)delegate
        {
            HideCaret(textBox2.Handle); 
            textBox2.SelectAll();              
        });          
    }
