    Image image = Image.LoadFromFile(...);
    DateTime lastEvent = DateTime.Now;
    float x = 0, y = 0;
    float dy = -100f; // distance to move per second
    
    void Update(TimeSpan elapsed) {
        y += (elapsed.TotalMilliseconds * dy / 1000f);
        if (y <= -image.Height) y += image.Height;
    }
    void OnTimer(object sender, EventArgs e) {
        TimeSpan elapsed = DateTime.Now.Subtract(lastEvent);
        lastEvent = DateTime.Now;
        Update(elapsed);
        this.Refresh();
    }
    void OnPaint(object sender, PaintEventArgs e) {
        e.Graphics.DrawImage(image, x, y);
        e.Graphics.DrawImage(image, x, y + image.Height);
    }
