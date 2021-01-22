    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(Keys vKey);
    
    private void theForm_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.ShiftKey)
    	{
    		if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)))
    		{
    			Console.WriteLine("Left");
    		}
    		if (Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
    		{
    			Console.WriteLine("Right");
    		}
    	}
    }
