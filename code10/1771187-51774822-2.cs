    public const int WM_VSCROLL = 0x0115;
    public const int SB_BOTTOM = 7;
    
    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    
    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
    	try
    	{
    		//scroll terminal to latest char
    		richTextBoxConsole.SelectionStart = richTextBoxConsole.Text.Length;
    		SendMessage(richTextBoxConsole.Handle, WM_VSCROLL, SB_BOTTOM, 0);
    
    		//Send character to port
    		serialPort1.Write(e.KeyChar.ToString());
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
