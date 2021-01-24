    private async void button1_Click(object sender, EventArgs e)
    {
        if (_buffer == null)
        {
            _buffer = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
        }
        timer1.Enabled = true;
        await Task.Run(() => DrawToBuffer(_buffer));
        timer1.Enabled = false;
        DrawingPanel.Invalidate();
    }
