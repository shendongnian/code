    private void panel1_Click(object sender, EventArgs e) {
        using (Graphics g = this.panel1.CreateGraphics()) {
            Pen pen = new Pen(Color.Black, 2);
    
            g.DrawRectangle(pen, 100,100, 100, 200);
            
            pen.Dispose();
        }
    }
