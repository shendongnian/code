    private void panel1_MouseDown(object sender, MouseEventArgs e) {
    	using (Graphics g = this.panel1.CreateGraphics()) {
    		Pen pen = new Pen(Color.Black, 2);
    		Brush brush = new SolidBrush(this.panel1.BackColor);
    
    		g.FillRectangle(brush, this.panel1.Bounds);  // redraws background
    		g.DrawRectangle(pen, e.X, e.Y, 20, 20);
    
    		pen.Dispose();
    		brush.Dispose();
    	}
    }
