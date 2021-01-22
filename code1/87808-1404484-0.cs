    protected override void OnPaint(PaintEventArgs pe)
    {
      Graphics gfx = pe.Graphics;
      using (Pen pen = new Pen(Color.Blue))
      {
        gfx.DrawEllipse(pen, 10,10,10,10);
      }
    }
