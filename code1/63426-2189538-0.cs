    void buttonCapture_Click(object sender, Exception e)
    {
        this.Hide();
        BeginInvoke(new SimpleDelegate(CaptureForeground));
    }
    
            private void CaptureForeground()
    {
    	// delay...
    	System.Threading.Thread.Sleep(500 + (1000 * (int)numericUpDownDelay.Value));
    
    	// Get foreground window rect using native calls
    	IntPtr hWnd = GetForegroundWindow();
    	RECT rct = new RECT();
    	GetWindowRect(hWnd, ref rct);
    
    	Rectangle r = new Rectangle();
    	r.Location = new Point(rct.Left, rct.Top);
    	r.Size = new Size(rct.Right - rct.Left, rct.Bottom - rct.Top);
    	CaptureBitmap(r);
    
    	this.Show();
    }
    
    private void CaptureBitmap(Rectangle r)
    {
    	bitmap = new Bitmap(r.Width, r.Height);
    	{
    		using (Graphics g = Graphics.FromImage(bitmap))
    		{
    			g.CopyFromScreen(r.Location, new Point(0, 0), r.Size);
    		}
    	}
    }
