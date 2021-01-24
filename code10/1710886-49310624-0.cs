    private class SelectedControl
    {
        public SelectedControl() { this.Control = null; this.Focused = false; }
        public Control Control { get; set; }
        public bool Focused { get; set; }
        public Color BorderColor { get; set; }
        public void Set()
        {
            Rectangle rect = this.Control.Bounds;
            rect.Inflate(2, 2);
            this.Control.FindForm().Invalidate(rect);
        }
    }
    private SelectedControl ControlWithBorder = new SelectedControl();
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (ControlWithBorder.Control != null) {
            Pen pen = new Pen((ControlWithBorder.Focused ? ControlWithBorder.BorderColor 
                                                         : Color.Transparent), 2);
            Rectangle rect = ControlWithBorder.Control.Bounds;
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
    private void comboBox1_Leave(object sender, EventArgs e)
    {
        ControlWithBorder.Control = comboBox1;
        ControlWithBorder.Focused = false;
        ControlWithBorder.Set();
    }
    private void comboBox1_Enter(object sender, EventArgs e)
    {
        ControlWithBorder.Control = comboBox1;
        ControlWithBorder.Focused = true;
        ControlWithBorder.BorderColor = Color.OrangeRed;
        ControlWithBorder.Set();
    }
