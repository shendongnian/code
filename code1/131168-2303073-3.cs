    private int startTime;  // set this to System.Environment.TickCount when you start
	
	// Add this line to the constructor
	this.UpdateBufferSize();
	
	private void UpdateBufferSize()
	{
		if (this.buffer != null)
		{
			this.buffer.Dispose();
		}
		this.buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
	}
    private void RefreshBuffer()
    {
        int timeElapsed = Environment.TickCount - this.startTime;
        using (Graphics g = Graphics.FromImage(this.buffer))
        {
            g.Clear(this.BackColor);
            foreach (MovingBitmap movingBitmap in this.bitmaps)
            {
                Rectangle destRectangle = new Rectangle(
                    movingBitmap.PositionFunction(timeElapsed), 
                    movingBitmap.Bitmap.Size);
                g.DrawImage(movingBitmap.Bitmap, destRectangle);
            }
        }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.DrawImage(this.buffer, Point.Empty);
    }
	
